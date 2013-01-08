using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestGetCity")]
	public class RequestGetCity : XmlRequestBase
	{
		public RequestGetCity ()
		{
		}
		
		public RequestGetCity(Country Country){
			this.Country = Country;
		}
		
		[XmlElement("Country")]
		public Country Country {
			get;
			set;
		}
		
	}
}

