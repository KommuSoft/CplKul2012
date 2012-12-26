using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Flight
	{
		public int ID { get; set; }
		public int location { get; set; }
		public int airline { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public List<int> classPrice { get; set; }

		public Flight (int ID, int location, int airline, DateTime start, DateTime end, List<int> classPrice)
		{
			this.ID = ID;
			this.location = location;
			this.airline = airline;
			this.start = start;
			this.end = end;
			this.classPrice = classPrice;
		}

		public Flight (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			location = reader.GetInt32(reader.GetOrdinal("location"));
			airline = reader.GetInt32(reader.GetOrdinal("airline"));
			
			DateTime start_time = reader.GetDateTime(reader.GetOrdinal("start_time"));
			DateTime start_date = reader.GetDateTime(reader.GetOrdinal("start_date"));
			start = new DateTime(start_date.Year, start_date.Month, start_date.Day, start_time.Hour, start_time.Minute, start_time.Second);
			
			DateTime end_time = reader.GetDateTime(reader.GetOrdinal("end_time"));
			DateTime end_date = reader.GetDateTime(reader.GetOrdinal("end_date"));
			end = new DateTime(end_date.Year, end_date.Month, end_date.Day, end_time.Hour, end_time.Minute, end_time.Second);
			
			string classePrices = reader.GetString(reader.GetOrdinal("class_price"));
			classPrice = Util.parse<int>(classePrices);
		}

		public override string ToString ()
		{
			return string.Format ("[Flight: ID={0}, location={1}, airline={2}, start={3}, end={4}, classPrice={5}]", ID, location, airline, start, end, classPrice);
		}
	}
}

