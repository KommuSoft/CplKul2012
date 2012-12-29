using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class CityRequest : DatabaseRequest<City>
	{
		public CityRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM city";
		}

		public List<City> fetchCityFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
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

