using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class CityRequest : DatabaseRequest<City>
	{
		public CityRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM city";
		}

		public List<City> fetchCityFromCountry (int countryID)
		{
			return fetchFromQuery(createQuery("country", countryID));
		}

		public List<City> fetchCityFromCountry (Country country)
		{
			CountryRequest cr = new CountryRequest();
			return fetchFromQuery(createBase() + " WHERE country = " +  cr.toQuery(country));
		}

		public List<City> fetchCityFromName (string name)
		{
			return fetchFromQuery (createQuery("name", name));
		}

		public List<City> fetchFromNameAndCountry (string cityName, string countryName)
		{
			CountryRequest cr = new CountryRequest();
			int countryID = cr.fetchCountryFromName(countryName)[0].ID;

			List<string> columns = new List<string>{"country", "name"};
			List<object> values = new List<object>{countryID, cityName};

			return fetchFromQuery(createQuery(columns, values));
		}

		public string toQuery (City city)
		{
			string query = "(SELECT id FROM city ";
			
			List<string> columns = new List<string>();
			List<object> values = new List<object>();
			
			if (city.name.Length != 0) {
				columns.Add("name");
				values.Add(city.name);
			}
			
			query = query + createWhere(columns, values) + ")";
			
			return query;
		}
	}
}

