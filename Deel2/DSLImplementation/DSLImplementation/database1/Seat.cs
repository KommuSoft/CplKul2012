using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class Seat
	{
		public int ID { get; set; }
		public int class_ { get; set; }
		public int number { get; set; }

		public Seat (int ID, int class_, int number)
		{
			this.ID = ID;
			this.class_ = class_;
			this.number = number;
		}

		public Seat (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			class_ = reader.GetInt32(reader.GetOrdinal("class"));
			number = reader.GetInt32(reader.GetOrdinal("number"));
		}

		public override string ToString ()
		{
			return string.Format ("[Seat: ID={0}, class_={1}, number={2}]", ID, class_, number);
		}

		//TODO: insert schrijven
	}
}

