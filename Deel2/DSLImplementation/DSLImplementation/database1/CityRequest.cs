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

		public List<City> fetchCityFromCountryName (string countryName)
		{
			//TODO: dit moet mooier
			return fetchFromQuery("select * from city where country = (select id from country where name ILIKE '" + countryName + "')");
		}

		public List<City> fetchCityFromName (string name)
		{
			return fetchFromQuery (createQuery("name", name));
		}
	}
}

