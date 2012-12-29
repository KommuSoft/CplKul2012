using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class City : SingleID
	{
		public string name { get; set; }
		public int country { get; set; }

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

		public override string ToString ()
		{
			return string.Format ("[City: ID={0}, name={1}, country={2}]", ID, name, country);
		}

		protected override bool isValid ()
		{
			return name.Length > 0 && country != -1;
		}
	}
}

