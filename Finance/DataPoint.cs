using System;
using System.Globalization;
using System.Data;

namespace Finance
{
    public class DataPoint
    {
        public DataPoint(DataRow row)
        {
            Name = row["Name"].ToString();
            DateValue = DateTime.Parse(row["Date"].ToString());
            LTP = decimal.Parse(row["LTP"].ToString());
            Time = DateTime.Parse(row["Time"].ToString());
            Volume = decimal.Parse(row["Volume"].ToString());
            Ask = decimal.Parse(row["Ask"].ToString());
            Bid = decimal.Parse(row["Bid"].ToString());
            High = decimal.Parse(row["High"].ToString());
            Low = decimal.Parse(row["Low"].ToString());
            SymbolID = int.Parse(row["SymbolID"].ToString());
            DateTimeValue = DateTime.ParseExact(row["Time"].ToString(), "dd/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            //Convert from EDT => IST
            DateTimeValue = DateTimeValue.AddHours(9.5);
            //TimeZoneInfo EDT_ZONE = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //TimeZoneInfo IST_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTimeValue = TimeZoneInfo.ConvertTime(DateTimeValue, EDT_ZONE, IST_ZONE);
        }

        public string Name {get;set;}
        public DateTime DateValue {get; set;}
        public decimal LTP {get; set;}
        public DateTime Time { get; set; }
        public decimal Volume {get; set;}
        public decimal Ask {get; set;}
        public decimal Bid {get; set;}
        public decimal High {get; set;}
        public decimal Low {get; set;}
        public int SymbolID {get; set;}
        public DateTime DateTimeValue { get; set; }
    }
}
