using System;
using System.Collections.Generic;


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

			List<Database.Country> countries = cr.fetchCountryFromName (this.City.Country.Name);
			if (countries.Count == 0) {
				return new AnswerAdd("No country found with name " + this.City.Country.Name);
			}

			int countryID = countries[0].ID;
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

