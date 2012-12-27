using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airline
	{
		public int ID { get; set; }
		public string code { get; set; }
		public string name { get; set; }

		public Airline (int ID, string code, string name)
		{
			this.ID = ID;
			this.code = code;
			this.name = name;
		}

		public Airline (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			code = reader.GetString(reader.GetOrdinal("code"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string ToString ()
		{
			return string.Format ("[Airline: ID={0}, code={1}, name={2}]", ID, code, name);
		}
	}
}

