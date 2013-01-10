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

		public List<Airplane> fetchAirplaneFromCode (string code)
		{
			List<string> columns = new List<string>{"code"};
			List<object> values = new List<object>{code};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

