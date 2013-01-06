using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class PassengerRequest : DatabaseRequest<Passenger>
	{
		public PassengerRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM passenger";
		}

		public string toQuery (Passenger passenger)
		{
			string query = "(SELECT id FROM passenger ";
			
			List<string> columns = new List<string>();
			List<object> values = new List<object>();
			
			if (passenger.name.Length != 0) {
				columns.Add("name");
				values.Add(passenger.name);
			}
			
			query = query + createWhere(columns, values) + ")";
			
			return query;
		}

		public List<Passenger> fetchPassengerFromName(string name)
		{
			List<string> columns = new List<string>{"name"};
			List<object> values = new List<object>{name};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

