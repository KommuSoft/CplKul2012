using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class AirportRequest
	{
		private Database db;

		public AirportRequest ()
		{
			db = new Database();
		}

		private string createQuery (string column, int value)
		{
			return "SELECT id, name, country, city, company FROM airport WHERE " + column + " = " + value; 
		}

		private Airport createAirport (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			string name = reader.GetString(reader.GetOrdinal("name"));
			int country = reader.GetInt32(reader.GetOrdinal("country"));
			int city = reader.GetInt32(reader.GetOrdinal("city"));
			
			string companies = reader.GetString(reader.GetOrdinal("company"));
			List<int> company = Util.parse<int>(companies);

			return new Airport(ID: ID, name: name, country: country, city: city, company: company);
		}

		public Airport fetchAirportFromID(int ID)
		{
			IDataReader reader = db.CreateCommand(createQuery("id", ID));
			
			reader.Read();
			Airport airport = createAirport(reader);

			reader.Close();
			reader = null;
			db.CloseCommand();

			return airport;
		}
		
		public List<Airport> fetchAirportsFromCity (int cityID)
		{
			string query = "SELECT id, name, country, city, company FROM airport WHERE city = " + cityID;	
			IDataReader reader = db.CreateCommand(query);
			List<Airport> airports = new List<Airport>();

			while (reader.Read()) {
				airports.Add(createAirport(reader));
			}
			
			reader.Close();
			reader = null;
			db.CloseCommand();

			return airports;
		}
	}
}

