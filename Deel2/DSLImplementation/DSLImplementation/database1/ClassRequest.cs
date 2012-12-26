using System;
using System.Collections.Generic;
using System.Data;

namespace DSLImplementation.Database
{
	public class ClassRequest : DatabaseRequest<Class>
	{
		public ClassRequest () : base() {}
		
		protected override string createQuery (string column, int value)
		{
			return "SELECT id, name FROM class WHERE " + column + " = " + value;
		}
		
		public List<Class> fetchClassFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}

		public List<Class> fetchClassFromFlight (int flightID)
		{
			IDataReader reader = db.CreateCommand("SELECT class_price FROM flight WHERE id = " + flightID);

			reader.Read();
			List<int> classPriceIDs = Util.parse<int>(reader.GetString(reader.GetOrdinal("class_price")));

			List<Class> classes = new List<Class>();
			foreach(int classPriceID in classPriceIDs){
				ClassPriceRequest cpr = new ClassPriceRequest();
				List<ClassPrice> classPrices = cpr.fetchClassPriceFromID(classPriceID);
				if(classPrices.Count == 0){
					return new List<Class>();
				}
				ClassPrice cp = classPrices[0];
				classes.Add(fetchClassFromID(cp.class_)[0]);
			}

			return classes;
		}

	}
}

