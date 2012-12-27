using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class Passenger
	{
		public int ID { get; set; }
		public string name { get; set; }

		public Passenger (int ID, string name)
		{
			this.ID = ID;
			this.name = name;
		}

		public Passenger (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string ToString ()
		{
			return string.Format ("[Passenger: ID={0}, name={1}]", ID, name);
		}
	}
}

