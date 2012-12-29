using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirlineRequest : DatabaseRequest<Airline>
	{
		public AirlineRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM airline";
		}

		public List<Airline> fetchAirlineFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

