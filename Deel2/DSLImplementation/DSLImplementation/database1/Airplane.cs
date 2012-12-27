using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airplane
	{
		public int ID { get; set; }
		public List<int> seat { get; set; }
		public string type { get; set; }

		public Airplane (int ID, List<int> seat, string type)
		{
			this.ID = ID;
			this.seat = seat;
			this.type = type;
		}

		public Airplane (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			seat = Util.parse<int>(reader.GetString(reader.GetOrdinal("seat")));
			type = reader.GetString(reader.GetOrdinal("type"));
		}

		public override string ToString ()
		{
			return string.Format ("[Airplane: ID={0}, seat={1}, type={2}]", ID, seat, type);
		}
	}
}

