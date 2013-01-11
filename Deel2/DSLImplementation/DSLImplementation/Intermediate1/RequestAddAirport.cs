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

		public override IAnswer execute ()
		{
			Database.CountryRequest cor = new Database.CountryRequest ();
			Database.CityRequest cir = new Database.CityRequest ();

			if (this.Airport.City == null) {
				return new AnswerAdd("The city of the airport isn't set.");
			}

			List<Database.Country> countries = cor.fetchCountryFromName (this.Airport.City.Country.Name);
			if (countries.Count != 1) {
				return new AnswerAdd ("No (unique) country found with name " + this.Airport.City.Country.Name);
			}
			int countryID = countries [0].ID;

			List<Database.City> cities = cir.fetchFromNameAndCountry(this.Airport.City.Name, this.Airport.City.Country.Name);
			if (cities.Count != 1) {
				return new AnswerAdd("No (unique) city found with name " + this.Airport.City.Name + " in country " + this.Airport.City.Country.Name);
			}
			int cityID = cities[0].ID;

			AnswerAdd aa = new AnswerAdd ();
			Database.Airport airport = new Database.Airport (name: this.Airport.Name, code: this.Airport.Code, country: countryID, city: cityID);

			try {
				airport.insert();
			} catch (Database.InvalidObjectException e){
				aa = new AnswerAdd(e.Message);
			} catch (Exception e) {
				aa = new AnswerAdd(e.ToString());
			}

			return aa;
		}
		
	}
}

