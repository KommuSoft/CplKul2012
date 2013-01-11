using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Seat : DatabaseTable
	{
		public int class_ { get; set; }
		public int number { get; set; }
		public int airplane { get; set; }

		public Seat ()
		{
			class_ = -1;
			number = -1;
			airplane = -1;
		}

		public Seat (int ID, int class_, int number, int airplane) : this(class_, number, airplane)
		{
			this.ID = ID;
		}

		public Seat (int class_, int number, int airplane)
		{
			this.class_ = class_;
			this.number = number;
			this.airplane = airplane;
		}

		public Seat (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			class_ = reader.GetInt32(reader.GetOrdinal("class"));
			number = reader.GetInt32(reader.GetOrdinal("number"));
			airplane = reader.GetInt32(reader.GetOrdinal("airplane"));
		}

		public override string tableName ()
		{
			return "seat";
		}

		public override string ToString ()
		{
			return string.Format ("[Seat: class_={0}, number={1}, airplane={2}]", class_, number, airplane);
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
			List<string> columns = new List<string>{"class", "number", "airplane"};
			List<object> values = new List<object>{class_, number, airplane};
			
			return base.insert(columns, values);
		}
	}
}

