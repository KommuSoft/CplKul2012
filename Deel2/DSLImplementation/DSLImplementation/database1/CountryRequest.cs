using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class CountryRequest : DatabaseRequest<Country>
	{
		public CountryRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM country";
		}

		public List<Country> fetchCountryFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

