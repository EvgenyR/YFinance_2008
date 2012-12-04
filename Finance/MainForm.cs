using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Finance
{
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); //logging

        FinanceBrowser fb;

        SqlConnection conn = new SqlConnection();
        SqlDataAdapter daData = new SqlDataAdapter();
        SqlDataAdapter daSymbol = new SqlDataAdapter();

        DataSet dsData = new DataSet();
        DataSet dsSymbol = new DataSet();

        BindingSource dataBS = new BindingSource();
        BindingSource symbolBS = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            CreateDataAdapterCommands();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = Properties.Settings.Default.FinanceConnectionString;

            try
            {
                conn.Open();

                daData.Fill(dsData);
                daSymbol.Fill(dsSymbol);

                dataBS.DataSource = dsData.Tables[0];
                symbolBS.DataSource = dsSymbol.Tables[0];
            }
            catch (Exception ex)
            {
                log.Fatal("Can not populate tables", ex);
            }

            txtUsername.Text = "ttester414@yahoo.com";
            txtPassword.Text = "123456";

            fb = new FinanceBrowser(dsData, daData, dsSymbol);
            fb.DataDownloaded += new FinanceBrowser.EventHandler(fb_DataDownloaded);
            fb.Authenticated += new FinanceBrowser.EventHandler(fb_Authenticated);

            SetUpDataGridViewColumns();
        }

        void fb_Authenticated(object sender, EventArgs args)
        {
            lblCookies.Text = "Authenticated";
        }

        void fb_DataDownloaded(object sender, EventArgs args)
        {
            List<DataPoint> dataPoints = ((FinanceBrowser)sender).latestData;
            dataGridViewData.Rows.Clear();
            foreach (DataPoint dataPoint in dataPoints)
            {
                string[] rowString = new string[] { dataPoint.Name, dataPoint.DateTimeValue.ToString(), dataPoint.LTP.ToString(), dataPoint.Time.ToString(), dataPoint.Volume.ToString(), dataPoint.Ask.ToString(), dataPoint.Bid.ToString(), dataPoint.High.ToString(), dataPoint.Low.ToString() };
                dataGridViewData.Rows.Add(rowString);
                dataGridViewData.Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.symbolBS.EndEdit();
                this.daSymbol.Update(this.dsSymbol);

                if (fb != null)
                {
                    fb.GetDownloadUrl();
                }
                MessageBox.Show("Changes Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            fb.Login = txtUsername.Text;
            fb.Password = txtPassword.Text;
            fb.Authenticate();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            fb.DownloadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fb.StopDownloading();
        }

        private void SetUpDataGridViewColumns()
        {
            dataGridViewSymbols.AutoGenerateColumns = false;
            dataGridViewSymbols.Columns[0].DataPropertyName = "Name";
            dataGridViewSymbols.DataSource = dsSymbol.Tables[0];
            dataGridViewSymbols.Refresh();

            dataGridViewData.AutoGenerateColumns = false;
            dataGridViewData.Columns[0].DataPropertyName = "Name";
            dataGridViewData.Columns[1].DataPropertyName = "Date";
            dataGridViewData.Columns[2].DataPropertyName = "LTP";
            dataGridViewData.Columns[3].DataPropertyName = "Time";
            dataGridViewData.Columns[4].DataPropertyName = "Volume";
            dataGridViewData.Columns[5].DataPropertyName = "Ask";
            dataGridViewData.Columns[6].DataPropertyName = "Bid";
            dataGridViewData.Columns[7].DataPropertyName = "High";
            dataGridViewData.Columns[8].DataPropertyName = "Low";
            dataGridViewData.Refresh();
        }

        private void CreateDataAdapterCommands()
        {
            string selectData = "SELECT SymbolId, Name, Date, LTP, Time, Volume, Ask, Bid, High, Low FROM dbo.Data";
            string selectSymbol = "SELECT Id, Name FROM dbo.Symbol";

            daData.SelectCommand = new SqlCommand(selectData, conn);
            daSymbol.SelectCommand = new SqlCommand(selectSymbol, conn);

            string insertData = @"INSERT INTO [dbo].[Data] ([SymbolId], [Name], [Date], [LTP], [Time], [Volume], [Ask], [Bid], [High], [Low]) 
                VALUES (@SymbolId, @Name, @Date, @LTP, @Time, @Volume, @Ask, @Bid, @High, @Low);
                SELECT Id, SymbolId, Name, Date, LTP, Time, Volume, Ask, Bid, High, Low FROM Data WHERE (Id = SCOPE_IDENTITY())";
            string deleteData = @"DELETE FROM [dbo].[Data]";

            daData.DeleteCommand = new SqlCommand(deleteData, conn);

            daData.InsertCommand = new SqlCommand(insertData, conn);
            daData.InsertCommand.Parameters.Add(new SqlParameter("@SymbolId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SymbolId", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@LTP", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "LTP", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Time", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Volume", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "Volume", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Ask", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "Ask", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Bid", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "Bid", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@High", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "High", DataRowVersion.Current, false, null, "", "", ""));
            daData.InsertCommand.Parameters.Add(new SqlParameter("@Low", SqlDbType.Decimal, 0, ParameterDirection.Input, 18, 2, "Low", DataRowVersion.Current, false, null, "", "", ""));

            string insertSymbol = @"INSERT INTO [dbo].[Symbol] ([Name]) VALUES (@Name); SELECT Id, Name FROM Symbol WHERE (Id = SCOPE_IDENTITY())";
            string updateSymbol = @"UPDATE [dbo].[Symbol] SET [Name] = @Name WHERE ([Id] = @Id); SELECT Id, Name FROM Symbol WHERE (Id = @Id)";
            string deleteSymbol = @"DELETE FROM [dbo].[Symbol] WHERE ([Id] = @Original_Id)";

            daSymbol.DeleteCommand = new SqlCommand(deleteSymbol, conn);
            daSymbol.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));

            daSymbol.InsertCommand = new SqlCommand(insertSymbol, conn);
            daSymbol.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));

            daSymbol.UpdateCommand = new SqlCommand(updateSymbol, conn);
            daSymbol.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
            daSymbol.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
        }
    }
}