using System;
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

		private string addAdditional(int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime)){
			string query = "";

			if (airline != -1) {
				query += " AND airline = " + airline;
			}
			
			if (class_ != -1) {
				query += " AND id = any(select flight.id from flight,seat_price,seat where seat_price.flight=flight.id AND seat_price.seat=seat.id AND seat.class = " + class_ +  " group by flight.id)";
			}
			
			if (startDateTime != default(DateTime)) {
				query += " AND extract(day FROM start_date) = " + startDateTime.Day;
				query += " AND extract(month FROM start_date) = " + startDateTime.Month;
				query += " AND extract(year FROM start_date) = " + startDateTime.Year;
			}

			return query;
		}

		public List<Flight> fetchFlight (Airport startAirport, Airport destinationAirport, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			LocationRequest lr = new LocationRequest();
			string query = lr.queryLocationFromAirports(startAirport, destinationAirport);

			query = "SELECT * FROM flight WHERE location = " + query;
			query += addAdditional(airline, class_, startDateTime);
			Console.WriteLine(query);

			return fetchFromQuery(query);
		}

		public List<Flight> fetchFlight (int locationID, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			List<string> columns = new List<string> {"location"};
			List<object> values = new List<object> {locationID};

			string query = createQuery (columns, values);
			query += addAdditional(airline, class_, startDateTime);
			Console.WriteLine("My query is: " + query);
			
			return fetchFromQuery(query);
		}
	}
}

