using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Country : DatabaseTable, ILocatable
	{
		public string name { get; set; }

		public Country ()
		{
			name = "";
		}

		public Country (int ID, string name = "") : this(name) {
			this.ID = ID;
		}

		public Country (string name = "")
		{
			this.name = name;
		}

		public Country (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string tableName ()
		{
			return "country";
		}

		public override string ToString ()
		{
			return string.Format ("[Country: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the country is invalid");
			}

			CountryRequest cr = new CountryRequest ();
			if (cr.fetchCountryFromName (name).Count != 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the country is invalid because it already exists.");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"name"};
			List<object> values = new List<object>{name};
			
			return base.insert(columns, values);
		}
	}
}

