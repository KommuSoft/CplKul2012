using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Country : SingleID
	{
		public string name { get; set; }

		public Country (int ID, string name = "") : this(name) {
			this.ID = ID;
		}

		public Country (string name = "")
		{
			this.name = name;
		}

		public Country (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string tableName ()
		{
			return "country";
		}

		public override string ToString ()
		{
			return string.Format ("[Country: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				exceptionMessage = "The name of the country is invalid";
				return false;
			}

			exceptionMessage = "";
			return true;
		}

		public override void insert ()
		{
			List<string> columns = new List<string>{"name"};
			List<object> values = new List<object>{name};
			
			base.insert(columns, values);
		}
	}
}

