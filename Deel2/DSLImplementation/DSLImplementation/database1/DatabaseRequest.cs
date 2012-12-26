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

		protected abstract string createQuery (string column, int value);

		protected void close (IDataReader reader)
		{
			reader.Close();
			reader = null;
			db.CloseCommand();
		}
	}
}

