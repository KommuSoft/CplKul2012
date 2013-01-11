using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestGetSeats : RequestBase
	{
		public RequestGetSeats (Flight flight, SeatClass seatClass = null)
		{
			this.flight = flight;
			this.seatClass = seatClass;
		}

		public Flight flight { get; set; }
		public SeatClass seatClass { get; set; }

		public override IAnswer execute ()
		{
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.FlightRequest fr = new Database.FlightRequest ();

			List<Database.Seat> databaseSeats = new List<Database.Seat> ();

			List<Database.Flight> flights = fr.fetchFlightFromCodeAndStartDate (flight.Template.Code, flight.StartDate);
			if (flights.Count != 1) {
				throw new Exception("No (unique) flight found with code " + flight.Template.Code + " and start date " + flight.StartDate);
			}
			int flightID =  flights[0].ID;

			if (seatClass != null) {
				Database.ClassRequest cr = new Database.ClassRequest ();
				List<Database.Class> classes = cr.fetchClassFromName (seatClass.Name);
				if(classes.Count != 1){
					throw new Exception("No (unique) class found with name " + seatClass.Name);
				}
				int classID =  classes[0].ID;

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

