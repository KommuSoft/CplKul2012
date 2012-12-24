using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("SeatRequest")]
	public class SeatRequest
	{
		public SeatRequest ()
		{
		}
		
		[XmlElement("Flight")]
		public Flight Flight {
			get;

			set;
		}
	}
}

