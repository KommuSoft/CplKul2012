using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class Location
	{
		public int ID { get; set; }
		public int start_airport { get; set; }
		public int destination_airport { get; set; }
		public int distance { get; set; }

		public Location (int ID, int start_airport, int destination_airport, int distance)
		{
			this.ID = ID;
			this.start_airport = start_airport;
			this.destination_airport = destination_airport;
			this.distance = distance;
		}

		public Location (IDataReader reader)
		{
			ID = reader.GetInt32(reader.GetOrdinal("id"));
			start_airport = reader.GetInt32(reader.GetOrdinal("start_airport"));
			destination_airport = reader.GetInt32(reader.GetOrdinal("destination_airport"));
			distance = reader.GetInt32(reader.GetOrdinal("distance"));
		}

		public override string ToString ()
		{
			return string.Format ("[Location: ID={0}, start_airport={1}, destination_airport={2}, distance={3}]", ID, start_airport, destination_airport, distance);
		}
	}
}

