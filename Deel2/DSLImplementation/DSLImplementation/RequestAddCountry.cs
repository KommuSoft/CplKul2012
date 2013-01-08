using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddCountry")]
	public class RequestAddCountry : XmlRequestBase
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
		
		public void execute(){
			Database.CountryRequest cr = new Database.CountryRequest();
		}
		
	}
}

