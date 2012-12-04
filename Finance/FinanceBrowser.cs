using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Finance
{
    public class FinanceBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); //logging
        public delegate void EventHandler(object sender, EventArgs args);
        public event EventHandler DataDownloaded = delegate { };
        public event EventHandler Authenticated = delegate { };

        private string _login;

        public string Login
        {
            set { _login = value; }
        }
        private string _password;

        public string Password
        {
            set { _password = value; }
        }

        public DataSet dsData { get; set; }
        public DataSet dsSymbol { get; set; }
        public SqlDataAdapter daData { get; set; }
        public List<DataPoint> latestData { get; set; }

        private const string LoginUrl = "https://login.yahoo.com/config/login";
        private const string MyYahoo = "my.yahoo.com";
        private CookieContainer _yahooContainer;
        private Uri _downloadUrl = null;
        private readonly Timer _timer;

        public FinanceBrowser(DataSet dataSet, SqlDataAdapter taData, DataSet symbolSet)
        {
            latestData = new List<DataPoint>();
            dsData = dataSet;
            daData = taData;
            dsSymbol = symbolSet;

            GetDownloadUrl();

            _timer = new Timer { Interval = 5000 };
            _timer.Tick += new System.EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DownloadData();
        }

        public void Authenticate()
        {
            string strPostData = String.Format("login={0}&passwd={1}", _login, _password);

            // Setup the http request.
            HttpWebRequest wrWebRequest = WebRequest.Create(LoginUrl) as HttpWebRequest;
            wrWebRequest.Method = "POST";
            wrWebRequest.ContentLength = strPostData.Length;
            wrWebRequest.ContentType = "application/x-www-form-urlencoded";
            _yahooContainer = new CookieContainer();
            wrWebRequest.CookieContainer = _yahooContainer;

            // Post to the login form.
            using (StreamWriter swRequestWriter = new StreamWriter(wrWebRequest.GetRequestStream()))
            {
                swRequestWriter.Write(strPostData);
                swRequestWriter.Close();
            }

            // Get the response.
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();

            if (hwrWebResponse.ResponseUri.AbsoluteUri.Contains(MyYahoo))
            {
                Authenticated(this, new EventArgs());
            }
        }

        public void DownloadData()
        {
            _timer.Stop();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_downloadUrl);
            req.CookieContainer = _yahooContainer;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader streamReader = new StreamReader(resp.GetResponseStream()))
            {
                string t = streamReader.ReadToEnd();
                string[] strings = t.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                InsertData(strings);
            }
        }

        internal void GetDownloadUrl()
        {
            // example url: "http://download.finance.yahoo.com/d/quotes.csv?s=ACC.NS+ICICIBANK.NS+ENGINERSI.NS&f=snd1l1t1vb3b2hg"
            string url = "http://download.finance.yahoo.com/d/quotes.csv?s=";

            try
            {
                int total = dsSymbol.Tables[0].Rows.Count;
                int count = 0;
                foreach (DataRow row in dsSymbol.Tables[0].Rows)
                {
                    url = url + row["Name"];
                    if (count < total - 1)
                    {
                        url = url + "+";
                    }
                    count++;
                }
                url = url + "&f=snd1l1t1vb3b2hg";
            }
            catch (Exception ex)
            {
                log.Fatal("Error retrieving download url: ", ex);
            }
            _downloadUrl = new Uri(url);
        }

        private void InsertData(IEnumerable<string> lines)
        {
            try
            {
                latestData.Clear();

                foreach (string line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        DataRow row = GetDatum(line);
                        dsData.Tables[0].Rows.Add(row);

                        DataPoint dataPoint = new DataPoint(row);
                        latestData.Add(dataPoint);
                    }
                }
                daData.Update(dsData.Tables[0]);
                DataDownloaded(this, new EventArgs());
            }
            catch (Exception ex)
            {
                log.Fatal("Exception in InsertData: ", ex);
            }

            _timer.Start();
        }

        private DataRow GetDatum(string line)
        {
            DataRow row = dsData.Tables[0].NewRow();

            try
            {
                string[] splitLine = line.Split(',');
                row["Name"] = splitLine[1].Replace("\"", "");
                row["Date"] = DateTime.ParseExact(splitLine[2].Replace("\"", ""), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                row["LTP"] = decimal.Parse(splitLine[3]);
                row["Time"] = DateTime.Parse(splitLine[4].Replace("\"", ""));
                row["Volume"] = decimal.Parse(splitLine[5]);
                row["Ask"] = decimal.Parse(splitLine[6]);
                row["Bid"] = decimal.Parse(splitLine[7]);
                row["High"] = decimal.Parse(splitLine[8]);
                row["Low"] = decimal.Parse(splitLine[9]);

                string expression = "Name='" + splitLine[0].Replace("\"", "") + "'";
                DataRow symbolRow = dsSymbol.Tables[0].Select(expression).FirstOrDefault();
                row["SymbolId"] = symbolRow["Id"];
            }
            catch (Exception ex)
            {
                log.Fatal("Exception in GetDatum: ", ex);
            }
            return row;
        }

        internal void StopDownloading()
        {
            _timer.Stop();
        }
    }
}