using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Airline : SingleID
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

		public override string ToString ()
		{
			return string.Format ("[Airline: ID={0}, code={1}, name={2}]", ID, code, name);
		}

		protected override bool isValid ()
		{
			return (code.Count() == 2 || code.Count() == 3) && name.Count() > 0;
		}

		public override void insert ()
		{
			List<string> columns = new List<string>{"code", "name"};
			List<object> values = new List<object>{code, name};

			base.insert("airline", columns, values);
		}
	}
}

