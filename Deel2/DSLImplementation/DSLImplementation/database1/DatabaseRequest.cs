using System;

namespace DSLImplementation.Database
{
	public abstract class DatabaseRequest
	{
		protected Database db;

		public DatabaseRequest ()
		{
			db = new Database();
		}

		protected abstract string createQuery (string column, int value);
	}
}

