using System;
using System.Collections.Generic;


namespace DSLImplementation.IntermediateCode
{
	public class RequestAddBooking : RequestBase
	{
		public RequestAddBooking (Booking Booking){
			this.Booking = Booking;
		}

		public Booking Booking{ get; set; }

		public override IAnswer execute ()
		{
			Database.FlightRequest fr = new Database.FlightRequest ();
			Database.PassengerRequest pr = new Database.PassengerRequest ();
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.ClassRequest cr = new Database.ClassRequest ();
			Database.AirplaneRequest ar = new Database.AirplaneRequest ();

			List<Database.Class> classes = cr.fetchClassFromName (this.Booking.Seat.SeatClass.Name);
			if (classes.Count != 1) {
				return new AnswerAdd ("No (unique) class found with name " + this.Booking.Seat.SeatClass.Name);
			}
			int classID = classes [0].ID;

			List<Database.Flight> flights = fr.fetchFlightFromCodeAndStartDate (code: this.Booking.Flight.Template.Code, startDate: this.Booking.Flight.StartDate);
			if (flights.Count != 1) {
				return new AnswerAdd("No (unique) flight found with code " + this.Booking.Flight.Template.Code + " at " + this.Booking.Flight.StartDate);
			}
			Database.Flight flight = flights[0];
			int flightID = flight.ID;

			List<Database.Airplane> airplanes = ar.fetchFromID (flight.airplane);
			int airplaneID = airplanes[0].ID;

			List<Database.Seat> seats = sr.fetchSeatFromClassNumberAndAirplane (class_: classID, number: this.Booking.Seat.Number, airplane: airplaneID);
			if (seats.Count != 1) {
				return new AnswerAdd ("No (unique) seat found with number " + this.Booking.Seat.Number + " from class " + this.Booking.Seat.SeatClass.Name);
			}
			int seatID = seats [0].ID;

			List<Database.Passenger> passengers = pr.fetchPassengerFromName (this.Booking.Passenger.Name);
			if (passengers.Count != 1) {
				return new AnswerAdd ("No (unique) passenger found with name " + this.Booking.Passenger.Name);
			}
			int passengerID = passengers [0].ID;

			Database.Booking booking = new Database.Booking (flight: flightID, passenger: passengerID, seat: seatID);
			AnswerAdd aa = new AnswerAdd ();

			try {
				booking.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
	}
}

