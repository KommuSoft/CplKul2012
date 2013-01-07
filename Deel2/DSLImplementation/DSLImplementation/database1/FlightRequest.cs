using System;
using System.Collections.Generic;
using System.Linq;

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
			return fetchFromQuery(query);
		}

		public List<Flight> fetchFlight (int locationID, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			List<string> columns = new List<string> {"location"};
			List<object> values = new List<object> {locationID};

			string query = createQuery (columns, values);
			query += addAdditional(airline, class_, startDateTime);
			
			return fetchFromQuery(query);
		}

		private void addJoin (List<string> tables, ref string where_, string table1, string alias1, string table2, string alias2, string column1, string column2)
		{
			string name1 = table1 + " as " + alias1;
			string name2 = table2 + " as " + alias2;
			if (!tables.Contains (name1)) {
				tables.Add (name1);
			}

			if (!tables.Contains (name2)) {
				tables.Add(name2);
			}

			where_ = where_ + alias1 + "." + column1 + " = " + alias2 + "." + column2 + " AND ";
		}

		public List<Flight> fetchFlight (Country startCountry, Country destinationCountry){
			List<string> tables = new List<string>{"flight as flight"};

			string where_ = "";
			addJoin(tables, ref where_, "location", "location", "flight", "flight", "id", "location");
			addJoin(tables, ref where_, "location", "location", "airport", "startAirport", "start_airport", "id");
			addJoin(tables, ref where_, "airport", "startAirport", "country", "startCountry", "country", "id");
			addJoin(tables, ref where_, "location", "location", "airport", "destinationAirport", "destination_airport", "id");
			addJoin(tables, ref where_, "airport", "destinationAirport", "country", "destinationCountry", "country", "id");

			string query = "SELECT flight.* FROM ";
			string from_ = string.Join(", ", (tables.Select(X=>X.ToString()).ToArray()));
			query += from_;
			query += " where ";
			query += where_;


			query += " startCountry.name ILIKE " + Util.parse (startCountry.name) + " AND " + " destinationCountry.name ILIKE " + Util.parse(destinationCountry.name);

			return fetchFromQuery(query);
		}
	}
}

