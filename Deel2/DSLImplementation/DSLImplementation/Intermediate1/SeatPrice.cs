using System;

namespace DSLImplementation.IntermediateCode
{
	public class SeatPrice
	{
		public SeatPrice (Seat seat, Flight flight, Decimal price)
		{
			this.seat = seat;
			this.flight = flight;
			this.price = price;
		}

		public Seat seat { get; set; }
		public Flight flight { get; set; }
		public Decimal price { get; set; }
	}
}

