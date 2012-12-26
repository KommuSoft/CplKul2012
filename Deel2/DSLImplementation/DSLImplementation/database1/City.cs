using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class City
	{
		public int ID { get; set; }
		public string name { get; set; }
		public int country { get; set; }

		public City (int ID, string name, int country)
		{
			this.ID = ID;
			this.name = name;
			this.country = country;
		}

		public City (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
			country = reader.GetInt32(reader.GetOrdinal("country"));
		}

		public override string ToString ()
		{
			return string.Format ("[City: ID={0}, name={1}, country={2}]", ID, name, country);
		}
	}
}

