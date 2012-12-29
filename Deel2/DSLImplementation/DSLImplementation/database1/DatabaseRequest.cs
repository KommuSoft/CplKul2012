using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public abstract class DatabaseRequest<T>
	{
		protected Database db;

		public DatabaseRequest ()
		{
			db = new Database();
		}

		protected List<T> fetchFromQuery (string query)
		{
			IDataReader reader = db.CreateCommand(query);
			List<T> objects = new List<T>();
			
			while (reader.Read()) {
				objects.Add((T)Activator.CreateInstance(typeof(T), reader));
			}
			
			close (reader);
			return objects;
		}

		protected abstract string createBase ();
		protected virtual string createQuery (List<string> columns, List<int> values)
		{
			return createBase() + createWhere(columns, values);
		}
		protected virtual string createQuery (string column, int value)
		{
			return createBase() + createWhere(new List<string>{column}, new List<int>{value});
		}

		//TODO: dit moet misschien nog algemener
		protected string createWhere (List<string> columns, List<int> values)
		{
			string query = " WHERE ";
			for (int i=0; i<columns.Count; ++i) {
				query += columns[i];
				query += " = ";
				query += Util.parse(values[i]);
				if(i < columns.Count - 1){
					query += " AND ";
				}
			}

			return query;
		}

		protected void close (IDataReader reader)
		{
			reader.Close();
			reader = null;
			db.CloseCommand();
		}
	}
}

