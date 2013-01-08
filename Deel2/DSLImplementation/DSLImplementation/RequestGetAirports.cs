using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestGetAirports")]
	public class RequestGetAirports : XmlRequestBase
	{
		public RequestGetAirports (City City, Country Country){//TODO: waarom country nog eens megeven? Zit al in City
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
		
	}
}

