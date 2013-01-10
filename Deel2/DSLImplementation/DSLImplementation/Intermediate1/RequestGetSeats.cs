using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestGetSeats : XmlRequestBase
	{
		public RequestGetSeats (Flight flight, SeatClass seatClass = null)
		{
			this.flight = flight;
			this.seatClass = seatClass;
		}

		public Flight flight { get; set; }
		public SeatClass seatClass { get; set; }

		public override IXmlAnswer execute ()
		{
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.FlightRequest fr = new Database.FlightRequest ();

			List<Database.Seat> databaseSeats = new List<Database.Seat> ();

			int flightID = fr.fetchFlightFromCodeAndStartDate (flight.Code, flight.StartDate) [0].ID;
			if (seatClass != null) {
				Database.ClassRequest cr = new Database.ClassRequest ();
				int classID = cr.fetchClassFromName (seatClass.Name) [0].ID;

				databaseSeats = sr.fetchSeatFromFlighAndClass (flightID, classID);
			} else {
				databaseSeats = sr.fetchSeatFromFlight (flightID);
			}

			List<Seat> seats = new List<Seat>();
			Database.ClassRequest clr = new Database.ClassRequest();
			foreach (Database.Seat s in databaseSeats) {
				SeatClass sc = new SeatClass(clr.fetchFromID(s.class_)[0].name);
				seats.Add(new Seat(sc, s.number));
			}

			return new AnswerGetSeats(seats);
		}
	}
}

