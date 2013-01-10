using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Class : DatabaseTable
	{
		public string name { get; set; }

		public Class ()
		{
			name = "";
		}

		public Class (int ID, string name) : this(name)
		{
			this.ID = ID;
		}

		public Class (string name)
		{
			this.name = name;
		}

		public Class (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string tableName ()
		{
			return "class";
		}

		public override string ToString ()
		{
			return string.Format ("[Class: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the class is invalid");
			}

			ClassRequest cr = new ClassRequest ();
			if (cr.fetchClassFromName (name).Count != 0) {
				return makeExceptionMessage(out exceptionMessage, "The name of the class already exists");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"name"};
			List<object> values = new List<object>{name};

			return base.insert(columns, values);
		}
	}
}

