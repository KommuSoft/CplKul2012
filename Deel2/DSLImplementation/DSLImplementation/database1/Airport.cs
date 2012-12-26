using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airport
	{
		public int ID { get; set; }
		public string name { get; set; }
		public int country { get; set; }
		public int city { get; set; }
		public List<int> company { get; set; }

		public Airport (int ID, string name, int country, int city, List<int> company)
		{
			this.ID = ID;
			this.name = name;
			this.country = country;
			this.city = city;
			this.company = company;
		}

		public Airport (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
			country = reader.GetInt32(reader.GetOrdinal("country"));
			city = reader.GetInt32(reader.GetOrdinal("city"));
				
			string companies = reader.GetString(reader.GetOrdinal("company"));
			company = Util.parse<int>(companies);
		}

		public override string ToString ()
		{
			return string.Format ("[Airport: ID={0}, name={1}, country={2}, city={3}, company={4}]", ID, name, country, city, company);
		}
	}
}

