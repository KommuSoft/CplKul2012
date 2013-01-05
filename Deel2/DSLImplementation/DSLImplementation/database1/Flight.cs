using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Flight : SingleID
	{
		public int location { get; set; }
		public int airline { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public int airplane { get; set; }
		public int template { get; set; }
		public DateTime travelTime { get; set; }

		public Flight ()
		{
			location = -1;
			airline = -1;
			start = default(DateTime);
			end = default(DateTime);
			airplane = -1;
			template = -1;
			travelTime = default(DateTime);
		}

		public Flight (int ID, int location, int airline, DateTime start, DateTime end, int airplane, int template, DateTime travelTime) : this(location, airline, start, end, airplane, template, travelTime)
		{
			this.ID = ID;
		}

		public Flight (int location, int airline, DateTime start, DateTime end, int airplane, int template, DateTime travelTime)
		{
			this.location = location;
			this.airline = airline;
			this.start = start;
			this.end = end;
			this.airplane = airplane;
			this.template = template;
			this.travelTime = travelTime;
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
			
			airplane = reader.GetInt32(reader.GetOrdinal("airplane"));
			template = reader.GetInt32(reader.GetOrdinal("template"));

			travelTime = reader.GetDateTime(reader.GetOrdinal("travel_time"));
		}

		public override string tableName ()
		{
			return "flight";
		}

		public override string ToString ()
		{
			return string.Format ("[Flight: ID={0}, location={1}, airline={2}, start={3}, end={4}, airplane={5}, template={6}, travelTime={7}]", ID, location, airline, start, end, airplane, template, travelTime);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			//TODO controleer de 3 tijdstippen (wss is elk tijdstip geldig, dus controleren is niet nodig)
			return validLocation(location, out exceptionMessage) && validAirline(airline, out exceptionMessage) && validAirplane(airplane, out exceptionMessage) && validTemplate(template, out exceptionMessage);
		}

		public override void insert(){
			List<string> columns = new List<string>{"location", "airline", "airplane", "template", "start_time", "start_date", "end_time", "end_date", "travel_time"};
			List<object> values = new List<object>{location, airline, airplane, template, Util.toTime(start), Util.toDate(start), Util.toTime(end), Util.toDate(end), Util.toTime(travelTime)};
			
			base.insert(columns, values);
		}
	}
}

