using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class PassengerRequest : DatabaseRequest<Passenger>
	{
		public PassengerRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT * FROM passenger WHERE " +  column + " = " + value;
		}

		public List<Passenger> fetchPassengerFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

