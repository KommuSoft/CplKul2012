using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirport")]
	public class RequestAddAirport : XmlRequestBase
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

		public override IXmlAnswer execute ()
		{
			throw new System.NotImplementedException ();
		}
		
	}
}

