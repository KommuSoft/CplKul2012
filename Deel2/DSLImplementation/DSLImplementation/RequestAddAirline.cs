using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirline")]
	public class RequestAddAirline
	{
		public RequestAddAirline(){
		}
		
		public RequestAddAirline(Airline Airline){
			this.Airline = Airline;
		}

		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}		
	}
}

