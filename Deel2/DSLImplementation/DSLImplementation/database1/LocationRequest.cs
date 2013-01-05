using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class LocationRequest : DatabaseRequest<Location>
	{
		public LocationRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM location";
		}

		public List<Location> fetchLocationFromAirports (int startAirport, int destinationAirport)
		{
			return fetchFromQuery(createQuery(new List<string>{"start_airport", "destination_airport"}, new List<object>{startAirport, destinationAirport}));
		}

		public string queryLocationFromAirports (Airport start, Airport destination)
		{
			AirportRequest ar = new AirportRequest();
			string startQuery = ar.toQuery(start);
			string destinationQuery = ar.toQuery(destination);

			return "(SELECT id FROM location WHERE start_airport = " + startQuery + " AND destination_airport = " + destinationQuery + ")";
		}
	}
}

