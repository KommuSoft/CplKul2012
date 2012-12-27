using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airport
	{
		public int ID { get; set; }
		public string code { get; set; }
		public string name { get; set; }
		public int country { get; set; }
		public int city { get; set; }
		public List<int> company { get; set; }

		public Airport (int ID, string name, string code, int country, int city, List<int> company)
		{
			this.ID = ID;
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
	
		public override string ToString ()
		{
			return string.Format ("[Airport: ID={0}, code={1}, name={2}, country={3}, city={4}, company={5}]", ID, code, name, country, city, company);
		}
	}
}

