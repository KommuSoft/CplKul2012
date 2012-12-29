using System;
using System.Data;
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

		public List<Location> fetchLocationFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

