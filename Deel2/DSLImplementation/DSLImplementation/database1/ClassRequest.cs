using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class ClassRequest
	{
		private Database db;
		
		public ClassRequest ()
		{
			db = new Database();
		}
		
		private string createQuery (string column, int value)
		{
			return "SELECT id, name FROM class WHERE " + column + " = " + value;
		}
		
		private Class createClass (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			string name = reader.GetString(reader.GetOrdinal("name"));
			return new Class(ID: ID, name: name);
		}
		
		public Class fetchClassFromID (int ID)
		{
			IDataReader reader = db.CreateCommand(createQuery("id", ID));
			
			reader.Read();
			Class class_ = createClass(reader);
			
			reader.Close();
			reader = null;
			db.CloseCommand();
			
			return class_;
		}

		public List<Class> fetchClassFromFlight (int flightID)
		{
			IDataReader reader = db.CreateCommand("SELECT class_price FROM flight WHERE id = " + flightID);

			reader.Read();
			List<int> classPriceIDs = Util.parse<int>(reader.GetString(reader.GetOrdinal("class_price")));

			List<Class> classes = new List<Class>();
			foreach(int classPriceID in classPriceIDs){
				ClassPriceRequest cpr = new ClassPriceRequest();
				ClassPrice cp = cpr.fetchClassPriceFromID(classPriceID);
				classes.Add(fetchClassFromID(cp.class_));
			}

			return classes;
		}

	}
}

