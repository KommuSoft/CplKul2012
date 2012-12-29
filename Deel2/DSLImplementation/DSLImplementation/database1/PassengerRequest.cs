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

		public List<Passenger> fetchPassengerFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

