using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Flight : DatabaseTable
	{
		public int location { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public int airplane { get; set; }
		public int template { get; set; }
		public TimeSpan travelTime { get; set; }

		public Flight ()
		{
			location = -1;
			start = default(DateTime);
			end = default(DateTime);
			airplane = -1;
			template = -1;
			travelTime = default(TimeSpan);
		}

		public Flight (int ID, int location, DateTime start, DateTime end, int airplane, int template, TimeSpan travelTime) : this(location, start, end, airplane, template, travelTime)
		{
			this.ID = ID;
		}

		public Flight (int location, DateTime start, DateTime end, int airplane, int template, TimeSpan travelTime)
		{
			this.location = location;
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
			
			DateTime start_time = reader.GetDateTime(reader.GetOrdinal("start_time"));
			DateTime start_date = reader.GetDateTime(reader.GetOrdinal("start_date"));
			start = new DateTime(start_date.Year, start_date.Month, start_date.Day, start_time.Hour, start_time.Minute, start_time.Second);
			
			DateTime end_time = reader.GetDateTime(reader.GetOrdinal("end_time"));
			DateTime end_date = reader.GetDateTime(reader.GetOrdinal("end_date"));
			end = new DateTime(end_date.Year, end_date.Month, end_date.Day, end_time.Hour, end_time.Minute, end_time.Second);
			
			airplane = reader.GetInt32(reader.GetOrdinal("airplane"));
			template = reader.GetInt32(reader.GetOrdinal("template"));

			DateTime travelDateTime = reader.GetDateTime(reader.GetOrdinal("travel_time"));
			travelTime = new TimeSpan(days: travelDateTime.Day, hours: travelDateTime.Hour, minutes: travelDateTime.Minute, seconds: travelDateTime.Second);
		}

		public override string tableName ()
		{
			return "flight";
		}

		public override string ToString ()
		{
			return string.Format ("[Flight: location={0}, start={1}, end={2}, airplane={3}, template={4}, travelTime={5}]", location, start, end, airplane, template, travelTime);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (!validTemplate (template, out exceptionMessage)) {
				return false;
			}

			FlightTemplateRequest ftr = new FlightTemplateRequest ();
			FlightTemplate flightTemplate = ftr.fetchFromID (template) [0];
			string code = flightTemplate.code;

			if (code == null) {
				code = flightTemplate.generateCode();
			}

			FlightRequest fr = new FlightRequest ();
			if (fr.fetchFlightFromCodeAndStartDate (code, start).Count() != 0) {
				return makeExceptionMessage(out exceptionMessage, "There is already a flight with code " + code + " at " + start);
			}

			//TODO controleer de 3 tijdstippen (wss is elk tijdstip geldig, dus controleren is niet nodig)
			return validLocation(location, out exceptionMessage) && validAirplane(airplane, out exceptionMessage);
		}

		public override int insert(){
			List<string> columns = new List<string>{"location", "airplane", "template", "start_time", "start_date", "end_time", "end_date", "travel_time"};
			List<object> values = new List<object>{location, airplane, template, Util.toTime(start), Util.toDate(start), Util.toTime(end), Util.toDate(end), Util.toTimeSpan(travelTime)};
			
			return base.insert(columns, values);
		}
	}
}

