using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirportRequest : DatabaseRequest<Airport>
	{
		public AirportRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, name, country, city, company FROM airport WHERE " + column + " = " + value; 
		}

		public List<Airport> fetchAirportFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
		
		public List<Airport> fetchAirportsFromCity (int cityID)
		{
			return fetchFromQuery(createQuery("city", cityID));
		}
	}
}

