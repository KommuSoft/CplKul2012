using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestGetCity")]
	public class RequestGetCities
	{
		public RequestGetCities ()
		{
		}
		
		public RequestGetCities(Country Country){
			this.Country = Country;
		}
		
		[XmlElement("Country")]
		public Country Country {
			get;
			set;
		}
		
	}
}

