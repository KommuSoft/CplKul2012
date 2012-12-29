using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddCountry")]
	public class RequestAddCountry
	{
	
		public RequestAddCountry ()
		{
		}		
		
		public RequestAddCountry (Country Country){
			this.Country = Country;
		}		
		
		[XmlElement("Country")]
		public Country Country{
			get;
			set;
		}
		
	}
}

