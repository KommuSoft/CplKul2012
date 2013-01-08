using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddFlightTemplate")]
	public class RequestAddFlightTemplate : XmlRequestBase
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

		public override IXmlAnswer execute ()
		{
			throw new System.NotImplementedException ();
		}

	}
}

