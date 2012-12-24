using System;
using System.Data;
using Npgsql;

namespace DSLImplementation.Database
{
	public class Database
	{
		private IDbConnection dbcon;
		private IDbCommand dbcmd;

		public Database ()
		{
			string connectionString = "Server=localhost; Database=DB; User ID=postgres; Password=postgres;";
			dbcon = new NpgsqlConnection(connectionString);
			dbcon.Open();
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

		~Database()
		{
			if(dbcmd != null){
				CloseCommand();
			}
			//dbcon.Close();
			//dbcon = null;
		}
	}
}

