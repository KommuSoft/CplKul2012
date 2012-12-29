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

		public List<Airport> fetchAirportFromCode (string code)
		{
			return fetchFromQuery(createQuery("code", code));
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

		public List<Airport> fetchAirportFromCityAndCountry (City city, Country country)
		{
			CityRequest cir = new CityRequest();
			CountryRequest cor = new CountryRequest();

			return fetchFromQuery("SELECT * FROM airport WHERE country = " + cor.toQuery(country) + " AND city = " + cir.toQuery(city));
		}

		public string toQuery (Airport airport)
		{
			string query = "(SELECT id FROM airport";

			List<string> columns = new List<string>();
			List<object> values = new List<object>();

			if (airport.code.Length != 0) {
				columns.Add("code");
				values.Add(airport.code);
			}

			if(airport.name.Length != 0){
				columns.Add("name");
				values.Add(airport.name);
			}

			return query + createWhere(columns, values) + ")";
		}
	}
}

