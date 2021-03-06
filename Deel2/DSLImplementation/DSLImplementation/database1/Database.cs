using System;
using System.Data;
using Npgsql;

namespace DSLImplementation.Database
{
	public class Database
	{
		private static IDbConnection dbcon;
		private IDbCommand dbcmd;
		private static int counter = 0;

		public Database ()
		{
			string connectionString = "Server=localhost; Database=cpl; User ID=postgres; Password=postgres;";

			if (counter == 0) {
				dbcon = new NpgsqlConnection(connectionString);
				dbcon.Open();
			}
			++counter;
		}

		public IDataReader CreateCommand(string query)
		{
			dbcmd = dbcon.CreateCommand();
			dbcmd.CommandText = query;
			return dbcmd.ExecuteReader();
		}

		public void CloseCommand ()
		{
			dbcmd.Dispose();
			dbcmd = null;
		}

		~Database ()
		{
			if (dbcmd != null) {
				CloseCommand ();
			}
			--counter;
			if (counter == 0) {
				dbcon.Close();
				dbcon = null;
			}
		}
	}
}

