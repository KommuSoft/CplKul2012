using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class FlightRequest : DatabaseRequest
	{
		public FlightRequest () : base(){}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, location, airline, start_time, end_time, start_date, end_date, class_price FROM flight WHERE " + column + " = " + value;
		}

		private string createQuery (List<string> columns, List<int> values)
		{
			string query = "SELECT id, location, airline, start_time, end_time, start_date, end_date, class_price FROM flight WHERE ";
			for (int i=0; i<columns.Count; ++i) {
				query += columns[i];
				query += " = ";
				query += values[i];
				if(i < columns.Count - 1){
					query += " AND ";
				}
			}

			return query;
		}

		private Flight createFlight (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			int location = reader.GetInt32(reader.GetOrdinal("location"));
			int airline = reader.GetInt32(reader.GetOrdinal("airline"));

			DateTime start_time = reader.GetDateTime(reader.GetOrdinal("start_time"));
			DateTime start_date = reader.GetDateTime(reader.GetOrdinal("start_date"));
			DateTime start = new DateTime(start_date.Year, start_date.Month, start_date.Day, start_time.Hour, start_time.Minute, start_time.Second);

			DateTime end_time = reader.GetDateTime(reader.GetOrdinal("end_time"));
			DateTime end_date = reader.GetDateTime(reader.GetOrdinal("end_date"));
			DateTime end = new DateTime(end_date.Year, end_date.Month, end_date.Day, end_time.Hour, end_time.Minute, end_time.Second);

			string classePrices = reader.GetString(reader.GetOrdinal("class_price"));
			List<int> classPrice = Util.parse<int>(classePrices);

			return new Flight(ID: ID, airline:airline, location: location, start: start, end: end, classPrice: classPrice);
		}

		//TODO: vararg?
		public List<Flight> fetchFlightFromLocation(int locationID)
		{
			IDataReader reader = db.CreateCommand(createQuery("location", locationID));
			List<Flight> flights = new List<Flight>();
			
			while (reader.Read()) {
				flights.Add(createFlight(reader));
			}
			
			reader.Close();
			reader = null;
			db.CloseCommand();
			
			return flights;
		}


	}
}

