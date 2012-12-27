using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class CountryRequest : DatabaseRequest<Country>
	{
		public CountryRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT * FROM country WHERE " + column + " = " + value;
		}

		public List<Country> fetchCountryFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

