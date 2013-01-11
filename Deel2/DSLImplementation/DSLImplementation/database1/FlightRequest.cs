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

		//TODO: overal waar er in deze klasse airline staat moet dit ontbonden worden
		private string addStartDateTime(DateTime startDateTime = default(DateTime)){
			string query = "";

			if (startDateTime != default(DateTime)) {
				query += " AND extract(day FROM start_date) = " + startDateTime.Day;
				query += " AND extract(month FROM start_date) = " + startDateTime.Month;
				query += " AND extract(year FROM start_date) = " + startDateTime.Year;
			}

			return query;
		}

		public List<Flight> fetchFlight (ILocatable start, ILocatable destination, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			if (start.GetType () == typeof(Airport) && start.GetType () == typeof(Airport)) {
				Airport startAirport = (Airport)start;
				Airport destinationAirport = (Airport)destination;

				return fetchFlight (startAirport, destinationAirport, airline, class_, startDateTime);
			} else if (start.GetType () == typeof(Country) && destination.GetType () == typeof(Country)) {
				Country startCountry = (Country)start;
				Country destinationCountry = (Country)destination;
				
				return fetchFlight (startCountry, destinationCountry, airline, class_, startDateTime);
			} else if (start.GetType () == typeof(City) && destination.GetType () == typeof(City)) {
				City startCity = (City) start;
				City destinationCity = (City) destination;
				
				return fetchFlight (startCity, destinationCity, airline, class_, startDateTime);
			} else {
				throw new InvalidObjectException("Couldn't find the type of the start or end location. Maybe they aren't of the same type.");
			}
		}

		public List<Flight> fetchFlight (Airport startAirport, Airport destinationAirport, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			LocationRequest lr = new LocationRequest();
			List<string> tables = new List<string>{"flight"};
			
			string where_ = "";
			addClass(tables, ref where_, class_);
			addAirline(tables, ref where_, airline);
			
			string query = "SELECT DISTINCT flight.* FROM ";
			string from_ = string.Join(", ", (tables.Select(X=>X.ToString()).ToArray()));
			query += from_;
			query += " WHERE ";
			query += where_;
			
			query += "location = " + lr.queryLocationFromAirports(startAirport, destinationAirport);
			query += addStartDateTime(startDateTime);
			
			Console.WriteLine(query);
			return fetchFromQuery(query);
		}

		public List<Flight> fetchFlight (int locationID, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			throw new NotImplementedException();
			//List<string> columns = new List<string> {"location"};
			//List<object> values = new List<object> {locationID};

			//string query = createQuery (columns, values);

			//TODO: code van class toevoegen
			//query += addAdditional(airline, startDateTime);
			//return fetchFromQuery(query);
		}

		private void addClass (List<string> tables, ref string where_, int class_)
		{
			if (class_ != -1) {
				addJoin(tables, ref where_, "seat_price", "flight", "flight", "id");
				addJoin(tables, ref where_, "seat_price", "seat", "seat", "id");
				where_ += "seat.class = " + class_ + " AND "; 
			}
		}

		private void addAirline (List<string> tables, ref string where_, int airline)
		{
			if (airline != -1) {
				addJoin(tables, ref where_, "flight_template", "flight", "id", "template");
				where_ += "flight_template.airline = " + airline + " AND ";
			}
		}

		private void addJoin (List<string> tables, ref string where_, string table1, string table2, string column1, string column2, string alias1 = "", string alias2 = "")
		{
			string name1 = table1;
			if (alias1.Length > 0) {
				name1 += " as " + alias1;
			}

			string name2 = table2;
			if(alias2.Length > 0){
				name2 += " as " + alias2;
			}

			if (!tables.Contains (name1)) {
				tables.Add (name1);
			}

			if (!tables.Contains (name2)) {
				tables.Add(name2);
			}

			where_ = where_ + ((alias1.Length > 0) ? alias1 : table1) + "." + column1 + " = " + ((alias2.Length > 0) ? alias2 : table2) + "." + column2 + " AND ";
		}

		public List<Flight> fetchFlight (Country startCountry, Country destinationCountry, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			List<string> tables = new List<string>{"flight"};

			string where_ = "";
			addJoin (tables, ref where_, "location", "flight", "id", "location");
			addJoin (tables, ref where_, "location", "airport", "start_airport", "id", alias2: "startAirport");
			addJoin (tables, ref where_, "airport", "country", "country", "id", alias1: "startAirport", alias2: "startCountry");
			addJoin (tables, ref where_, "location", "airport", "destination_airport", "id", alias2: "destinationAirport");
			addJoin (tables, ref where_, "airport", "country", "country", "id", alias1: "destinationAirport", alias2: "destinationCountry");

			addClass(tables, ref where_, class_);
			addAirline(tables, ref where_, airline);

			string query = "SELECT DISTINCT flight.* FROM ";
			string from_ = string.Join(", ", (tables.Select(X=>X.ToString()).ToArray()));
			query += from_;
			query += " WHERE ";
			query += where_;

			query += " startCountry.name " + Util.fetchOperator(startCountry.name.GetType()) + Util.parse (startCountry.name) + " AND " + " destinationCountry.name " + Util.fetchOperator(destinationCountry.name.GetType()) + Util.parse(destinationCountry.name) + addStartDateTime(startDateTime);

			Console.WriteLine(query);
			return fetchFromQuery(query);
		}

		public List<Flight> fetchFlight (City startCity, City destinationCity, int airline = -1, int class_ = -1, DateTime startDateTime = default(DateTime))
		{
			List<string> tables = new List<string>{"flight"};

			string where_ = "";
			addJoin(tables, ref where_, "location", "flight", "id", "location");
			addJoin(tables, ref where_, "location", "airport", "start_airport", "id", alias2: "startAirport");
			addJoin(tables, ref where_, "airport", "city", "city", "id", alias1: "startAirport", alias2: "startCity");
			addJoin(tables, ref where_, "location", "airport", "destination_airport", "id",  alias2: "destinationAirport");
			addJoin(tables, ref where_, "airport", "city", "city", "id", alias1: "destinationAirport", alias2: "destinationCity");

			addClass(tables, ref where_, class_);
			addAirline(tables, ref where_, airline);

			string query = "SELECT DISTINCT flight.* FROM ";
			string from_ = string.Join(", ", (tables.Select(X => X.ToString()).ToArray()));
			query += from_;
			query += " WHERE ";
			query += where_;

			query += " startCity.name " + Util.fetchOperator(startCity.name.GetType()) + Util.parse(startCity.name) + " AND " + " destinationCity.name " + Util.fetchOperator(destinationCity.name.GetType()) + Util.parse(destinationCity.name) + addStartDateTime(startDateTime);

			Console.WriteLine(query);
			return fetchFromQuery(query);
		}

		public List<Flight> fetchFlightFromCodeAndStartDate (string code, DateTime startDate)
		{
			string airlineCode = "";
			string digits = "";
			Util.split (code, ref airlineCode, ref digits);

			AirlineRequest ar = new AirlineRequest ();
			List<Airline> airlines = ar.fetchAirlineFromCode (airlineCode);
			if (airlines.Count () != 1) {
				throw new InvalidObjectException("No airline with code " + airlineCode + " was found");
			}
			int airlineID = airlines[0].ID;

			List<string> tables = new List<string>{"flight"};

			string where_ = "";
			addJoin(tables, ref where_, "flight", "flight_template", "template", "id");

			string query = "SELECT flight.* FROM ";
			string from_ = string.Join(", ", (tables.Select(X => X.ToString()).ToArray()));
			query += from_;
			query += " WHERE ";
			query += where_;

			query += " start_date = '" + Util.toDate(startDate) + "' AND ";
			query += " start_time = '" + Util.toTime(startDate) + "' AND ";
			query += " flight_template.airline =  " + airlineID + " AND ";
			query += " flight_template.digits " + Util.fetchOperator(digits.GetType()) + Util.parse(digits);

			Console.WriteLine(query);
			return fetchFromQuery(query);
		}
	}
}

