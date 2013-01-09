using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
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

			AnswerAdd aa = new AnswerAdd();
			try{
				c.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
		
	}
}

