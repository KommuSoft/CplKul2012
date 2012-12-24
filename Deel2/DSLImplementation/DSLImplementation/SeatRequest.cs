using System;
namespace DSLImplementation
{
	[XmlRoot("SeatRequest")]
	public class SeatRequest
	{
		public SeatRequest ()
		{
		}
		
		[XmlElement("Flight")]
		public Flight Flight {
			get { return this.flight; }

			set { this.flight = value; }
		}
	}
}

