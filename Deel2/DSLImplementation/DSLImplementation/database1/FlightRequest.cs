using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class FlightRequest : DatabaseRequest<Flight>
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

		public List<Flight> fetchFlightFromLocation (int locationID, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			List<string> columns = new List<string> ();
			columns.Add ("location");

			List<int> values = new List<int> ();
			values.Add (locationID);

			if (airline != -1) {
				columns.Add ("airline");
				values.Add (airline);
			}

			string query = createQuery (columns, values);
			if (class_ != -1) {
				query += " AND array(SELECT id FROM class_price WHERE class = " + class_ + ") && (class_price)";
			}

			if (startDateTime != default(DateTime)) {
				query += " AND extract(day FROM start_date) >= " + startDateTime.Day;
				query += " AND extract(month FROM start_date) >= " + startDateTime.Month;
				query += " AND extract(year FROM start_date) >= " + startDateTime.Year;
			}

			return fetchFromQuery(query);
		}
	}
}

