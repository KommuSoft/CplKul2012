using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirplaneRequest : DatabaseRequest<Airplane>
	{
		public AirplaneRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM airplane";
		}

		public List<Airplane> fetchAirplaneFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

