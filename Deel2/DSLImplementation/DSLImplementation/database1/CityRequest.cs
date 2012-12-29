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

		public List<City> fetchCitiesFromCountry (int countryID)
		{
			return fetchFromQuery(createQuery("country", countryID));
		}
	}
}

