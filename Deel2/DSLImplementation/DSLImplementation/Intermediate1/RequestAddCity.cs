using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddCity : XmlRequestBase
	{

		public RequestAddCity (City City){
			this.City = City;
		}		

		public City City{ get; set; }

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

