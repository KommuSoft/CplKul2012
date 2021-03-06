using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Passenger : DatabaseTable
	{
		public string name { get; set; }

		public Passenger ()
		{
			name = "";
		}

		public Passenger (int ID, string name = "") : this(name)
		{
			this.ID = ID;
		}

		public Passenger (string name = "")
		{
			this.name = name;
		}

		public Passenger (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			name = reader.GetString(reader.GetOrdinal("name"));
		}

		public override string tableName ()
		{
			return "passenger";
		}

		public override string ToString ()
		{
			return string.Format ("[Passenger: ID={0}, name={1}]", ID, name);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (name.Length == 0) {
				return makeExceptionMessage (out exceptionMessage, "The name of the passenger is invalid");
			}
		
			PassengerRequest pr = new PassengerRequest ();
			if (pr.fetchPassengerFromName (name).Count () != 0) {
				return makeExceptionMessage(out exceptionMessage, "There is already a passenger with the given name");
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

