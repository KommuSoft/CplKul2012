using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddCountry")]
	public class RequestAddCountry
	{
	
		public RequestAddCountry (Country Country){
			this.Country = Country;
		}		
		
		public RequestAddCountry ()
		{
		}
		
		[XmlElement("Country")]
		public Country Country{
			get;
			set;
		}
		
	}
}

