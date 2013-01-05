using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airplane : SingleID
	{
		public List<int> seat { get; set; }
		public string type { get; set; }

		public Airplane (int ID, List<int> seat, string type) : this(seat, type)
		{
			this.ID = ID;
		}

		public Airplane (List<int> seat, string type)
		{
			this.seat = seat;
			this.type = type;
		}

		public Airplane (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			seat = Util.parse<int>(reader.GetString(reader.GetOrdinal("seat")));
			type = reader.GetString(reader.GetOrdinal("type"));
		}

		public override string tableName ()
		{
			return "airplane";
		}

		public override string ToString ()
		{
			return string.Format ("[Airplane: ID={0}, seat={1}, type={2}]", ID, seat, type);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			foreach (int s in seat) {
				if(!validSeat(s, out exceptionMessage)){
					return false;
				}
			}

			if (type.Length == 0) {
				return makeExceptionMessage(out exceptionMessage, "The type of the airplane is invalid");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert(){
			List<string> columns = new List<string>{"seat", "type"};
			List<object> values = new List<object>{seat, type};

			return base.insert(columns, values);
		}
	}
}

