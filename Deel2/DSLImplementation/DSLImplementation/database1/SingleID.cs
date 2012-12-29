using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public abstract class SingleID
	{

		private bool hasID = false;
		private int id;
		
		public int ID {
			get {
				return id;
			}
			set{
				hasID = true;
				id = value;
			} }

		public SingleID () {}

		protected string createInsertQuery (string table, List<String> columns, List<Object> values)
		{
			string query = "INSERT INTO " + table;
			string columnQuery = String.Join(", ", columns.ToArray());
			string valuequery = String.Join(", ", values.Select(x => Util.parse(x)).ToArray());
			
			return query + "(" + columnQuery + ") VALUES(" + valuequery + ")";
		}

		protected abstract bool isValid();

		protected void insert (string table, List<string> columns, List<object> values)
		{
			if (!isValid ()) {
				throw new InvalidObjectException ("This airline object isn't valid.");
			}

			if (hasID) {
				columns.Insert(0, "id");
				values.Insert(0, ID);
			}

			string query = createInsertQuery(table, columns, values);
			Console.WriteLine(query);
			
			//Database db = new Database();
			//db.CreateCommand(query);
		}
	}
}

