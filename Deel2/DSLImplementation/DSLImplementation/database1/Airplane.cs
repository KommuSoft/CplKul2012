using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class Airplane : DatabaseTable
	{
		public List<int> seat { get; set; }
		public string type { get; set; }
		public string code { get; set; }

		public Airplane (int ID, List<int> seat, string type, string code) : this(seat, type, code)
		{
			this.ID = ID;
		}

		public Airplane (List<int> seat, string type, string code)
		{
			this.seat = seat;
			this.type = type;
			this.code = code;
		}

		public Airplane (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			seat = Util.parse<int>(reader.GetString(reader.GetOrdinal("seat")));
			type = reader.GetString(reader.GetOrdinal("type"));
			code = reader.GetString(reader.GetOrdinal("code"));
		}

		public override string tableName ()
		{
			return "airplane";
		}

		public override string ToString ()
		{
			return string.Format ("[Airplane: seat={0}, type={1}, code={2}]", seat, type, code);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			foreach (int s in seat) {
				if (!validSeat (s, out exceptionMessage)) {
					return false;
				}
			}

			if (type.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The type of the airplane is invalid");
			}

			if (code.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The code of the airplane is invalid");
			}

			AirplaneRequest ar = new AirplaneRequest ();
			if (ar.fetchAirplaneFromCode (code).Count != 0) {
				return makeExceptionMessage(out exceptionMessage, "The code of the airplane already exists for an airplane");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert(){
			List<string> columns = new List<string>{"seat", "type", "code"};
			List<object> values = new List<object>{seat, type, code};

			return base.insert(columns, values);
		}
	}
}

