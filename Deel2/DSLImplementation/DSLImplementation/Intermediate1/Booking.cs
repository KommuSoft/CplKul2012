using System;
namespace DSLImplementation.IntermediateCode
{
	public class Booking
	{
		public Booking (Passenger Passenger, Flight Flight, Seat Seat)
		{
			this.Passenger = Passenger;
			this.Flight = Flight;
			this.Seat = Seat;
		}

		public Passenger Passenger { get; set; }
		public Flight Flight { get; set; }
		public Seat Seat { get; set; }
		
	}
}

