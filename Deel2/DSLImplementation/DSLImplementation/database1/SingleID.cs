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

		protected abstract bool isValid(out string exceptionMessage);

		public virtual void insert ()
		{
			throw new Exception ("Not implemented yet");
		}

		protected void insert (string table, List<string> columns, List<object> values)
		{
			string exceptionMessage;
			if (!isValid (out exceptionMessage)) {
				throw new InvalidObjectException (exceptionMessage);
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

