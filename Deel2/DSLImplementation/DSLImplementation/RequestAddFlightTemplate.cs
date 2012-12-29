using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddFlightTemplate")]
	public class RequestAddFlightTemplate
	{
		
		public RequestAddFlightTemplate (){
		}
		
		public RequestAddFlightTemplate (FlightTemplate FlightTemplate){
			this.FlightTemplate = FlightTemplate;
		}
		
		[XmlElement("FlightTemplate")]
		public FlightTemplate FlightTemplate{
			get;
			set;
		}		
		
	}
}

