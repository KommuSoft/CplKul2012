using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class CountryRequest : DatabaseRequest<Country>
	{
		public CountryRequest () : base() {}

		public override string createBase ()
		{
			return "SELECT * FROM country";
		}

		public List<Country> fetchCountryFromName(string name)
		{
			return fetchFromQuery (createQuery("name", name));
		}

		public string toQuery (Country country)
		{
			string query = "(SELECT id FROM country ";

			List<string> columns = new List<string>();
			List<object> values = new List<object>();

			if (country.name.Length != 0) {
				columns.Add("name");
				values.Add(country.name);
			}

			query = query + createWhere(columns, values) + ")";

			return query;
		}
	}
}

