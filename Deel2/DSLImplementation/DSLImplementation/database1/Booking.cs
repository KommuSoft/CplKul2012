using System;

namespace DSLImplementation.Database
{
	public class Booking
		//TODO: klasse controleren/schrijven
	{
		public int ID { get; set; }
		public int flight { get; set; }
		public int passenger { get; set; }
		public int class_ { get; set; }
		public int seat { get; set; }

		public Booking (int flight, int passenger, int class_, int seat)
		{
			this.flight = flight;
			this.passenger = passenger;
			this.class_ = class_;
			this.seat = seat;
		}

		public void insert ()
		{
			string query = "INSERT INTO booking(flight, passenger, class, seat) VALUES( " + flight + ", " + passenger + ", " + class_ + ", " + seat + ");";

			Database db = new Database();
			db.CreateCommand(query);


//			string query = "INSERT INTO flight(airline, class, location, start_time, end_time, start_date, end_date, price) VALUES (1, '{1}', 2, '01:50', '02:50', '2012-04-12', '2012-04-12', '{30}');"
		}

		public override string ToString ()
		{
			return string.Format ("[Booking: ID={0}, flight={1}, passenger={2}, class_={3}, seat={4}]", ID, flight, passenger, class_, seat);
		}
	}
}

