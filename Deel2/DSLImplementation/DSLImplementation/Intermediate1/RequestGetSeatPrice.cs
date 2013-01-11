using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestGetSeatPrice : XmlRequestBase
	{
		public RequestGetSeatPrice (Flight flight, Seat seat)
		{
			this.flight = flight;
			this.seat = seat;
		}

		public Flight flight { get; set; }
		public Seat seat { get; set; }

		public override IAnswer execute ()
		{
			Database.SeatPriceRequest spr = new Database.SeatPriceRequest ();
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.FlightRequest fr = new Database.FlightRequest ();

			List<Database.Flight> flights = fr.fetchFlightFromCodeAndStartDate (flight.Template.Code, flight.StartDate);
			if (flights.Count != 1) {
				throw new Exception ("No (unique) flight with code " + flight.Template.Code + " and start date " + flight.StartDate + " could be found");
			}
			int flightID = flights [0].ID;

			List<Database.Seat> seats = sr.fetchSeatFromFlightAndNumber (flightID, seat.Number);
			if (seats.Count != 1) {
				throw new Exception ("No (unique) seat with number " + seat.Number + " is found on flight with code " + flight.Template.Code + " and start date " + flight.StartDate);
			}
			int seatID = seats [0].ID;

			List<Database.SeatPrice> seatPrices = spr.fetchSeatPriceFromSeatAndFlight (seatID, flightID);
			if (seatPrices.Count != 1) {
				throw new Exception("No (unique) seat price found for seat with number " + seat.Number + " is found on flight with code " + flight.Template.Code + " and start date " + flight.StartDate);
			}

			SeatPrice sp = new SeatPrice(seat, flight, seatPrices[0].price);
			return new AnswerGetSeatPrice(sp);
		}
	}
}

