using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class ClassRequest : DatabaseRequest<Class>
	{
		public ClassRequest () : base() {}
		
		protected override string createQuery (string column, int value)
		{
			return "SELECT id, name FROM class WHERE " + column + " = " + value;
		}
		
		public List<Class> fetchClassFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}

		public List<Class> fetchClassFromFlight (int flightID)
		{
			string query = "select * from class where id = any(select class from seat where id = any(select seat from seat_price where flight = " + flightID + ") group by class)";
			return fetchFromQuery(query);
		}

	}
}

