using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirlineRequest : DatabaseRequest<Airline>
	{
		public AirlineRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT * FROM airline WHERE " + column + " = " + value;
		}

		public List<Airline> fetchAirlineFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

