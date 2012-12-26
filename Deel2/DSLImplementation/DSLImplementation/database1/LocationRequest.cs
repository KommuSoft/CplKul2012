using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class LocationRequest : DatabaseRequest<Location>
	{
		public LocationRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, start_city, start_country, destination_city, destination_country FROM location WHERE " + column + " = " + value;
		}

		public List<Location> fetchLocationFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

