using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestAddSeatPrice : XmlRequestBase
	{
		public RequestAddSeatPrice (Seat seat, Flight flight, Decimal price)
		{
			this.seat = seat;
			this.flight = flight;
			this.price = price;
		}

		public Seat seat { get; set; }
		public Flight flight { get; set; }
		public Decimal price { get; set; }

		public override IAnswer execute ()
		{
			Database.FlightRequest fr = new Database.FlightRequest ();
			List<Database.Flight> flights = fr.fetchFlightFromCodeAndStartDate (flight.Template.Code, flight.StartDate);
			if (flights.Count != 1) {
				return new AnswerAdd ("No (unique) flight with code " + flight.Template.Code + " at " + flight.StartDate);
			}
			int flightID = flights [0].ID;

			Database.SeatRequest sr = new Database.SeatRequest ();
			List<Database.Seat> seats = sr.fetchSeatFromFlightAndNumber (flightID, seat.Number);
			if (seats.Count != 1) {
				return new AnswerAdd("No (unique) seat with number " + seat.Number + " at flight with code " + flight.Template.Code + " at " + flight.StartDate);
			}
			int seatID = seats[0].ID;
			Database.SeatPrice sp = new Database.SeatPrice(seatID, flightID, price);

			try{
				sp.insert();
			} catch(Exception e){
				return new AnswerAdd(e.Message);
			}

			return new AnswerAdd();
		}
	}
}

