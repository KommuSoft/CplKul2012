using System;

namespace DSLImplementation.Database
{
	public class DatabaseRequest
	{
		protected Database db;

		public DatabaseRequest ()
		{
			db = new Database();
		}
	}
}

