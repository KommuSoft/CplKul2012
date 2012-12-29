using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirport")]
	public class RequestAddAirport
	{
		public RequestAddAirport ()
		{
		}
		
		public RequestAddAirport (Airport Airport){
			this.Airport = Airport;
		}
		
		[XmlElement("Airport")]
		public Airport Airport{
			get;
			set;
		}	
		
	}
}

