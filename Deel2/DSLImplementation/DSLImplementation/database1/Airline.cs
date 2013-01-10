using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Airline : DatabaseTable
	{
		public string code { get; set; }
		public string name { get; set; }

		public Airline (int ID, string code, string name) : this(code, name)
		{
			this.ID = ID;
		}

		public Airline (string code, string name)
		{
			this.code = code;
			this.name = name;
		}

		public Airline (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			code = reader.GetString(reader.GetOrdinal("code"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string tableName ()
		{
			return "airline";
		}

		public override string ToString ()
		{
			return string.Format ("[Airline: ID={0}, code={1}, name={2}]", ID, code, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (code.Length != 2 && code.Length != 3) {
				return makeExceptionMessage (out exceptionMessage, "The code of the airline is invalid");
			}

			if (name.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the airline is invalid");
			}

			AirlineRequest ar = new AirlineRequest ();
			if (ar.fetchAirlineFromCode (code).Count != 0) {
				return makeExceptionMessage (out exceptionMessage, "The code of the airline already exists for an airline");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"code", "name"};
			List<object> values = new List<object>{code, name};

			return base.insert(columns, values);
		}
	}
}

