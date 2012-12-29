using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class Country : SingleID
	{
		public string name { get; set; }

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

		public override string ToString ()
		{
			return string.Format ("[Country: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid ()
		{
			return name.Length > 0;
		}
	}
}

