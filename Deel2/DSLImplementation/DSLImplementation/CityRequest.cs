using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("CityRequest")]
	public class CityRequest
	{
		public CityRequest ()
		{
		}
		
		public CityRequest(Country Country){
			this.Country = Country;
		}
		
		[XmlElement("Country")]
		public Country Country {
			get;
			set;
		}
		
	}
}

