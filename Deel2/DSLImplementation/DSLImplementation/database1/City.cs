using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class City : DatabaseTable, ILocatable
	{
		public string name { get; set; }
		public int country { get; set; }

		public City (){}

		public City (int ID, string name = "", int country = -1) : this(name, country)
		{
			this.ID = ID;
		}

		public City (string name = "", int country = -1)
		{
			this.name = name;
			this.country = country;
		}

		public City (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
			country = reader.GetInt32(reader.GetOrdinal("country"));
		}

		public override string tableName ()
		{
			return "city";
		}

		public override string ToString ()
		{
			return string.Format ("[City: ID={0}, name={1}, country={2}]", ID, name, country);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the city is invalid");
			}

			if (!validCountry (country, out exceptionMessage)) {
				return false;
			}

			CountryRequest cor = new CountryRequest ();
			string countryName = cor.fetchFromID (country) [0].name;
			CityRequest cr = new CityRequest ();
			if (cr.fetchFromNameAndCountry (name, countryName).Count () != 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the city already exists for a city in the country " + countryName);
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"name", "country"};
			List<object> values = new List<object>{name, country};

			return base.insert(columns, values);
		}
	}
}

