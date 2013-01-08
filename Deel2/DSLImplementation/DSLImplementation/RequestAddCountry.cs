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
		
		public override IXmlAnswer execute(){
			Database.Country c = new Database.Country(this.Country.Name);
			c.insert();

			//TODO implementeer het antwoord
			return null;
		}
		
	}
}

