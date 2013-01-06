using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class ClassRequest : DatabaseRequest<Class>
	{
		public ClassRequest () : base() {}
		
		protected override string createBase ()
		{
			return "SELECT * FROM class";
		}

		public List<Class> fetchClassFromFlight (int flightID)
		{
			string query = "SELECT * FROM class WHERE id = ANY(SELECT class FROM seat WHERE id = ANY(SELECT seat FROM seat_price WHERE flight = " + flightID + ") GROUP BY class)";
			return fetchFromQuery(query);
		}

		public List<Class> fetchClassFromFlightAndName(int flightID, string name)
		{
			string query = "SELECT * FROM class WHERE (name"+ Util.fetchOperator(name.GetType()) + Util.parse(name) + "AND id = ANY(SELECT class FROM seat WHERE id = ANY(SELECT seat FROM seat_price WHERE flight = " + flightID + ") GROUP BY class))";
			return fetchFromQuery(query);
		}
	}
}

