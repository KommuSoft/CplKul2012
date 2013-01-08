using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatRequest : DatabaseRequest<Seat>
	{
		public SeatRequest () : base() {}

		public override string createBase ()
		{
			return "SELECT * FROM seat";
		}

		public List<Seat> fetchSeatFromFlight (int flightID)
		{
			string query = "SELECT * FROM seat WHERE id = any(SELECT seat FROM seat_price WHERE flight = " + flightID + ")";
			return fetchFromQuery(query);
		}

		public List<Seat> fetchSeatFromFlighAndClass (int flightID, int class_)
		{
			string query = "SELECT * FROM seat WHERE (class = " + class_ + " AND id = any(SELECT seat FROM seat_price WHERE flight = " + flightID + "))";
			return fetchFromQuery(query);
		}

		public List<Seat> fetchSeatFromClassAndNumber (int class_, int number)
		{
			List<string> columns = new List<string>{"class", "number"};
			List<object> values = new List<object>{class_, number};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

