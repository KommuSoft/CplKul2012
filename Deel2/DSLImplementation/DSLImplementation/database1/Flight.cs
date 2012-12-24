using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class Flight
	{
		public int ID { get; set; }
		public int location { get; set; }
		public int airline { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public List<int> classPrice { get; set; }

		public Flight (int ID, int location, int airline, DateTime start, DateTime end, List<int> classPrice)
		{
			this.ID = ID;
			this.location = location;
			this.airline = airline;
			this.start = start;
			this.end = end;
			this.classPrice = classPrice;
		}

		public override string ToString ()
		{
			return string.Format ("[Flight: ID={0}, location={1}, airline={2}, start={3}, end={4}, classPrice={5}]", ID, location, airline, start, end, classPrice);
		}
	}
}

