using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirportRequest : DatabaseRequest<Airport>
	{
		public AirportRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM airport";
		}

		public List<Airport> fetchAirportFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
		
		public List<Airport> fetchAirportFromCity (int cityID)
		{
			return fetchFromQuery(createQuery("city", cityID));
		}

		public List<Airport> fetchAirportFromCityName (string cityName)
		{
			CityRequest cr = new CityRequest ();
			List<City> cities = cr.fetchCityFromName (cityName);
			List<Airport> airports = new List<Airport>(); 
			foreach (City city in cities) {
				airports.AddRange(fetchAirportFromID(city.ID));
			}

			return airports;
		}

		public List<Airport> fetchAirportFromCityNameAndCountryName (string cityName, string countryName)
		{
			CountryRequest cr = new CountryRequest();
			List<Country> countries = cr.fetchCountryFromName(countryName);

			List<Airport> airports = fetchAirportFromCityName (cityName);
			List<Airport> resultAirports = new List<Airport> ();

			foreach (Airport airport in airports) {
				if(countries.Exists(delegate(Country country){return country.ID == airport.country;})){
					resultAirports.Add(airport);
				}	
			}

			return resultAirports;
		}
	}
}

