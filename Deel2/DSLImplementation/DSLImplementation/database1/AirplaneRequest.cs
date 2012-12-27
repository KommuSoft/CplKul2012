using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirplaneRequest : DatabaseRequest<Airplane>
	{
		public AirplaneRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT * FROM airplane WHERE " + column + " = " + value;
		}

		public List<Airplane> fetchAirplaneFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

