using System;

namespace DSLImplementation.Database
{
	public class Location
	{
		public int ID { get; set; }
		public int start_city { get; set; }
		public int start_country { get; set; }
		public int destination_city { get; set; }
		public int destination_country { get; set; }

		public Location (int ID, int start_city, int start_country, int destination_city, int destination_country)
		{
			this.ID = ID;
			this.start_city = start_city;
			this.start_country = start_country;
			this.destination_city = destination_city;
			this.destination_country = destination_country;
		}

		public override string ToString ()
		{
			return string.Format ("[Location: ID={0}, start_city={1}, start_country={2}, destination_city={3}, destination_country={4}]", ID, start_city, start_country, destination_city, destination_country);
		}
	}
}

