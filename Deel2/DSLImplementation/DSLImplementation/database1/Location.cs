using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Location : DatabaseTable
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

		public override string tableName ()
		{
			return "location";
		}

		public override string ToString ()
		{
			return string.Format ("[Location: ID={0}, start_airport={1}, destination_airport={2}, distance={3}]", ID, start_airport, destination_airport, distance);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (distance <= 0) {
				return makeExceptionMessage (out exceptionMessage, "The distance bewteen the locations is invalid");
			}

			LocationRequest lr = new LocationRequest ();
			if (lr.fetchLocationFromAirports (start_airport, destination_airport).Count () != 0) {
				return makeExceptionMessage(out exceptionMessage, "There is already an traject between the given airports");
			}

			return validAirport(start_airport, out exceptionMessage) && validAirport(destination_airport, out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"start_airport", "destination_airport", "distance"};
			List<object> values = new List<object>{start_airport, destination_airport, distance};
			
			return base.insert(columns, values);
		}
	}
}

