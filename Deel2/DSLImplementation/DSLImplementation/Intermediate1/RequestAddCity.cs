using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("RequestAddCity")]
	public class RequestAddCity : XmlRequestBase
	{

		public RequestAddCity (){
		}		
		
		public RequestAddCity (City City){
			this.City = City;
		}		
		
		[XmlElement("City")]
		public City City{
			get;
			set;
		}

		public override IXmlAnswer execute ()
		{
			Database.CountryRequest cr = new Database.CountryRequest ();
			int countryID = cr.fetchCountryFromName (this.City.Country.Name)[0].ID;
			Database.City city = new Database.City (name: this.City.Name, country: countryID);

			AnswerAdd aa = new AnswerAdd();
			try {
				city.insert ();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
		
	}
}

