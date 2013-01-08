using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class BookingRequest : DatabaseRequest<Booking>
	{
		public BookingRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM booking";
		}

		public List<Booking> fetchBookingFromPassenger (Passenger passenger)
		{
			PassengerRequest pr = new PassengerRequest ();
			return fetchFromQuery ("SELECT * FROM booking where passenger = " + pr.toQuery (passenger));
		}
	}
}

