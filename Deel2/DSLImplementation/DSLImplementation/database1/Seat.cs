using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Seat : SingleID
	{
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

		public override string tableName ()
		{
			return "seat";
		}

		public override string ToString ()
		{
			return string.Format ("[Seat: ID={0}, class_={1}, number={2}]", ID, class_, number);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (number < 0) {
				exceptionMessage = "The number of the seat is invalid";
				return false;
			}

			return validClass(class_, out exceptionMessage);
		}

		public override void insert ()
		{
			List<string> columns = new List<string>{"class", "number"};
			List<object> values = new List<object>{class_, number};
			
			base.insert(columns, values);
		}
	}
}

