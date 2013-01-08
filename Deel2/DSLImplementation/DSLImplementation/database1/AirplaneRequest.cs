using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirplaneRequest : DatabaseRequest<Airplane>
	{
		public AirplaneRequest () : base() {}

		public override string createBase ()
		{
			return "SELECT * FROM airplane";
		}

		public List<Airplane> fetchAirplaneFromSeatAndType(string type, List<int> seats)
		{
			List<string> columns = new List<string>{"type", "seat"};
			List<object> values = new List<object>{type, seats};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

