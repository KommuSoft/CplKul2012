using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Passenger : SingleID
	{
		public string name { get; set; }

		public Passenger (int ID, string name)
		{
			this.ID = ID;
			this.name = name;
		}

		public Passenger (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string ToString ()
		{
			return string.Format ("[Passenger: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				exceptionMessage = "The name of the passenger is invalid";
				return false;
			}
		
			exceptionMessage = "";
			return true;
		}

		public override void insert ()
		{
			List<string> columns = new List<string>{"name"};
			List<object> values = new List<object>{name};
			
			base.insert("passenger", columns, values);
		}
	}
}

