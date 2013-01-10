using System;
using System.Collections.Generic;


namespace DSLImplementation.IntermediateCode
{
	public class RequestAddAirport : XmlRequestBase
	{
		public RequestAddAirport (Airport Airport){
			this.Airport = Airport;
		}

		public Airport Airport{ get; set; }	

		public override IXmlAnswer execute ()
		{
			Database.CountryRequest cor = new Database.CountryRequest ();
			Database.CityRequest cir = new Database.CityRequest ();

			List<Database.Country> countries = cor.fetchCountryFromName (this.Airport.City.Country.Name);
			if (countries.Count == 0) {
				return new AnswerAdd ("No country found with name " + this.Airport.City.Country.Name);
			}
			int countryID = countries [0].ID;

			List<Database.City> cities = cir.fetchCityFromName (this.Airport.City.Name);
			if (cities.Count == 0) {
				return new AnswerAdd("No city found with name " + this.Airport.City.Name);
			}
			int cityID = cities[0].ID;

			AnswerAdd aa = new AnswerAdd ();
			Database.Airport airport = new Database.Airport (name: this.Airport.Name, code: this.Airport.Code, country: countryID, city: cityID);

			try {
				airport.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.ToString());
			}

			return aa;
		}
		
	}
}

