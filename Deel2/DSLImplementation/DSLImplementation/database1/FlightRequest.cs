using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class FlightRequest : DatabaseRequest<Flight>
	{
		public FlightRequest () : base(){}

		protected override string createBase ()
		{
			return "SELECT * FROM flight";
		}

		public List<Flight> fetchFlight (int locationID, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
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
				query += " AND id = any(select flight.id from flight,seat_price,seat where seat_price.flight=flight.id AND seat_price.seat=seat.id AND seat.class = " + class_ +  " group by flight.id)";
			}
			
			if (startDateTime != default(DateTime)) {
				query += " AND extract(day FROM start_date) = " + startDateTime.Day;
				query += " AND extract(month FROM start_date) = " + startDateTime.Month;
				query += " AND extract(year FROM start_date) = " + startDateTime.Year;
			}

			Console.WriteLine("My query is: " + query);
			
			return fetchFromQuery(query);
		}
	}
}

