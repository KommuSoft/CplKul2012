using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlType("Booking")]
	public class Booking
	{
		public Booking ()
		{
		}
		
		public Booking (Passenger Passenger, Flight Flight, Seat Seat)
		{
			this.Passenger = Passenger;
			this.Flight = Flight;
			this.Seat = Seat;
		}
		
		
		[XmlElement("Passenger")]
		public Passenger Passenger {
			get;
			set;
		}
		
		[XmlElement("Flight")]
		public Flight Flight {
			get;
			set;
		}
		
		[XmlElement("Seat")]
		public Seat Seat {
			get;
			set;
		}
		
	}
}

