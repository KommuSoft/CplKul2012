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

		public virtual List<T> fetchFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}

		public virtual string tableName(){
			return ((DatabaseTable)Activator.CreateInstance(typeof(T))).tableName();
		}

		protected abstract string createBase ();
		protected virtual string createQuery (List<string> columns, List<object> values)
		{
			return createBase() + createWhere(columns, values);
		}

		protected virtual string createQuery<T1> (string column, T1 value)
		{
			return createBase() + createWhere(new List<string>{column}, new List<object>{value});
		}

		protected string createWhere (List<string> columns, List<object> values)
		{
			string query = " WHERE ";
			for (int i=0; i<columns.Count; ++i) {
				object val = values[i];

				query += columns[i];
				query += Util.fetchOperator(val.GetType());
				query += Util.parse(val);
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

