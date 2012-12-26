using System;
using System.Data;
using Npgsql;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DSLImplementation.Database
{
	public class Database
	{
		private static IDbConnection dbcon;
		private IDbCommand dbcmd;
		private static int counter = 0;

		public Database ()
		{
//			string connectionString = "Server=localhost; Database=DB; User ID=postgres1; Password=postgres;";
			string connectionString = "Server=localhost; Port=25432; Database=gonaz; User ID=gonaz; Password=cplPassword1;";

			if (counter == 0) {
				dbcon = new NpgsqlConnection(connectionString);
				dbcon.Open();
				++counter;
			}
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
				Console.WriteLine("I will close the database");
				dbcon.Close();
				dbcon = null;
			}
		}
	}
}

