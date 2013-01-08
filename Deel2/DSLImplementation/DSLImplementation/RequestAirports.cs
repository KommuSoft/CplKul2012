using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAirports")]
	public class RequestAirports : XmlRequestBase
	{
		public RequestAirports (City City, Country Country){
			this.City = City;
			this.Country = Country;
		}
		
		[XmlElement("City")]
		public City City{
			get;
			set;
		}
		
		[XmlElement("Country")]
		public Country Country{
			get;
			set;
		}

		public override IXmlAnswer execute ()
		{
			throw new System.NotImplementedException ();
		}
		
	}
}

