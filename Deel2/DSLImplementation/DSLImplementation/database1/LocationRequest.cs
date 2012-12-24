using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class LocationRequest : DatabaseRequest
	{
		public LocationRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, start_city, start_country, destination_city, destination_country FROM location WHERE " + column + " = " + value;
		}

		private Location createLocation (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			int start_city = reader.GetInt32(reader.GetOrdinal("start_city"));
			int start_country = reader.GetInt32(reader.GetOrdinal("start_country"));
			int destination_city = reader.GetInt32(reader.GetOrdinal("destination_city"));
			int destination_country = reader.GetInt32(reader.GetOrdinal("destination_country"));

			return new Location(ID: ID, start_city: start_city, start_country: start_country, destination_city: destination_city, destination_country: destination_country);
		}

		public Location fetchLocationFromID (int ID)
		{
			IDataReader reader = db.CreateCommand(createQuery("id", ID));
			
			reader.Read();
			Location location = createLocation(reader);
			
			reader.Close();
			reader = null;
			db.CloseCommand();
			
			return location;
		}
	}
}

