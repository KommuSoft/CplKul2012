using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddBooking")]
	public class RequestAddBooking
	{
		public RequestAddBooking (){
		}
		
		public RequestAddBooking (Booking Booking){
			this.Booking = Booking;
		}
		
		[XmlElement("Booking")]
		public Booking Booking{
			get;
			set;
		}
	}
}

