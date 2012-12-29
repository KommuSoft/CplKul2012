using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatRequest : DatabaseRequest<Seat>
	{
		public SeatRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM seat";
		}

		public List<Seat> fetchSeatFromFlight (int flightID)
		{
			string query = "SELECT * FROM seat WHERE id = any(SELECT seat FROM seat_price WHERE flight = " + flightID + ")";
			return fetchFromQuery(query);
		}

		public List<Seat> fetchSeatFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

