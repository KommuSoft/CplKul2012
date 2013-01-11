using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class RequestGetCities : RequestBase
	{
		public RequestGetCities(Country Country){
			this.Country = Country;
		}

		public Country Country { get; set; }

		public override IAnswer execute()
		{
			Database.CityRequest cr = new Database.CityRequest();
			List<Database.City> cities = cr.fetchCityFromCountry(new Database.Country(this.Country.Name));
			List<City> resultCities = new List<City>();
			foreach(Database.City c in cities){
				resultCities.Add(new City(Name: c.name, Country: this.Country));
			}

			return new AnswerGetCities(resultCities);
		}
		
	}
}

