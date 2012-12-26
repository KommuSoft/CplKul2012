using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatRequest : DatabaseRequest<Seat>
	{
		public SeatRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			throw new System.NotImplementedException ();
		}

		public List<Seat> fetchSeatFromFlight (int flightID)
		{
			string query = "SELECT id, class, number FROM seat WHERE id = any(SELECT seat FROM seat_price WHERE flight = " + flightID + ")";
			return fetchFromQuery(query);
		}
	}
}

