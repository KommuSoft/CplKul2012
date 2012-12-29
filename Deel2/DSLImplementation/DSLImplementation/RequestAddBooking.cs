using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddBooking")]
	public class RequestAddBooking
	{
		public RequestAddBooking ()
		{
		}
		
		[XmlElement("Booking")]
		public Booking Booking{
			get;
			set;
		}
	}
}

