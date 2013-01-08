using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirlineRequest : DatabaseRequest<Airline>
	{
		public AirlineRequest () : base() {}

		public override string createBase ()
		{
			return "SELECT * FROM airline";
		}

		public List<Airline> fetchAirlineFromCode(string code)
		{
			return fetchFromQuery(createQuery("code", code));
		}
	}
}

