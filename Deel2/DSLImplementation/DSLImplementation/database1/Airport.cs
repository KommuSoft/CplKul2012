using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Airport : DatabaseTable
	{
		public string code { get; set; }
		public string name { get; set; }
		public int country { get; set; }
		public int city { get; set; }
		public List<int> company { get; set; }

		public Airport ()
		{
			code = "";
			name = "";
			country = -1;
			city = -1;
			company = new List<int>();
		}

		public Airport (int ID, string name, string code, int country, int city, List<int> company) : this(name, code, country, city, company)
		{
			this.ID = ID;
		}

		public Airport (string name = "", string code = "", int country = -1, int city = -1, List<int> company = default(List<int>))
		{
			this.name = name;
			this.country = country;
			this.city = city;
			this.company = company;
			this.code = code;
		}

		public Airport (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
			country = reader.GetInt32(reader.GetOrdinal("country"));
			city = reader.GetInt32(reader.GetOrdinal("city"));
			code = reader.GetString(reader.GetOrdinal("code"));
				
			string companies = reader.GetString(reader.GetOrdinal("company"));
			company = Util.parse<int>(companies);
		}
	
		public override string tableName ()
		{
			return "airport";
		}

		public override string ToString ()
		{
			return string.Format ("[Airport: ID={0}, code={1}, name={2}, country={3}, city={4}, company={5}]", ID, code, name, country, city, company);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				return makeExceptionMessage(out exceptionMessage, "The name of the airport is invalid");
			}

			if (code.Length != 3 || !code.All (char.IsUpper)) {
				return makeExceptionMessage(out exceptionMessage, "The code of the airport is invalid");
			}

			return validCity (city, out exceptionMessage) && validCountry(country, out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"name", "country", "city", "code", "company"};
			List<object> values = new List<object>{name, country, city, code, company};

			return base.insert(columns, values);
		}
	}
}

