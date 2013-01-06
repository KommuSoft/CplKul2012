using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Seat : DatabaseTable
	{
		public int class_ { get; set; }
		public int number { get; set; }

		public Seat ()
		{
			class_ = -1;
			number = -1;
		}

		public Seat (int ID, int class_, int number) : this(class_, number)
		{
			this.ID = ID;
		}

		public Seat (int class_, int number)
		{
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
				return makeExceptionMessage(out exceptionMessage, "The number of the seat is invalid");
			}

			return validClass(class_, out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"class", "number"};
			List<object> values = new List<object>{class_, number};
			
			return base.insert(columns, values);
		}
	}
}

