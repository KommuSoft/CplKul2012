using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Booking : DatabaseTable
	{
		public int flight { get; set; }
		public int passenger { get; set; }
		public int seat { get; set; }

		public Booking (int flight, int passenger, int seat)
		{
			this.flight = flight;
			this.passenger = passenger;
			this.seat = seat;
		}

		public override string tableName ()
		{
			return "booking";
		}

		public override string ToString ()
		{
			return string.Format ("[Booking: ID={0}, flight={1}, passenger={2}, seat={3}]", ID, flight, passenger, seat);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			return validFlight(flight, out exceptionMessage) && validPassenger(passenger, out exceptionMessage) && validSeat(seat, out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"flight", "passenger", "seat"};
			List<object> values = new List<object>{flight, passenger, seat};
			
			return base.insert(columns, values);
		}
	}
}

