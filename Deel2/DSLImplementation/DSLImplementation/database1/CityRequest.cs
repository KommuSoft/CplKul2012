using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class CityRequest : DatabaseRequest<City>
	{
		public CityRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, name, country FROM city WHERE " + column + " = " + value;
		}

		public List<City> fetchCityFromID(int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}

		public List<City> fetchCitiesFromCountry (int countryID)
		{
			return fetchFromQuery(createQuery("country", countryID));
		}
	}
}

