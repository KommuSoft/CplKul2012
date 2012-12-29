using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Location : SingleID
	{
		public int start_airport { get; set; }
		public int destination_airport { get; set; }
		public int distance { get; set; }

		public Location (int ID, int start_airport, int destination_airport, int distance) : this(start_airport, destination_airport, distance)
		{
			this.ID = ID;
		}

		public Location (int start_airport, int destination_airport, int distance)
		{
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

		protected override bool isValid (out string exceptionMessage)
		{
			if (distance <= 0) {
				exceptionMessage = "The distance between the locations is invalid";
				return false;
			}

			AirportRequest ar = new AirportRequest();
			if (start_airport == -1 && ar.fetchAirportFromID(start_airport).Count != 1) {
				exceptionMessage = "The start airport of the location is invalid";
				return false;
			}

			if (destination_airport == -1 && ar.fetchAirportFromID(destination_airport).Count != 1) {
				exceptionMessage = "The destination airport of the location is invalid";
				return false;
			}

			exceptionMessage = "";
			return true;
		}

		public void insert ()
		{
			List<string> columns = new List<string>{"start_airport", "destination_airport", "distance"};
			List<object> values = new List<object>{start_airport, destination_airport, distance};
			
			base.insert("location", columns, values);
		}
	}
}

