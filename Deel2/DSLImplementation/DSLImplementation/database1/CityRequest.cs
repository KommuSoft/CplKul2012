using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class CityRequest : DatabaseRequest
	{
		public CityRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, name, country FROM city WHERE " + column + " = " + value;
		}

		private City createCity (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			string name = reader.GetString(reader.GetOrdinal("name"));
			int country = reader.GetInt32(reader.GetOrdinal("country"));

			return new City(ID: ID, name: name, country: country);
		}

		public City fetchCityFromID(int ID)
		{
			IDataReader reader = db.CreateCommand(createQuery("id", ID));

			reader.Read();
			City city = createCity(reader);

			reader.Close();
			reader = null;
			db.CloseCommand();

			return city;
		}

		public List<City> fetchCitiesFromCountry (int countryID)
		{
			IDataReader reader = db.CreateCommand (createQuery("country", countryID));

			List<City> cities = new List<City>();
			while (reader.Read()) {
				cities.Add(createCity(reader));
			}

			reader.Close();
			reader = null;
			db.CloseCommand();
			return cities;
		}
	}
}

