using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("RequestAddBooking")]
	public class RequestAddBooking : XmlRequestBase
	{
		public RequestAddBooking (){
		}
		
		public RequestAddBooking (Booking Booking){
			this.Booking = Booking;
		}
		
		[XmlElement("Booking")]
		public Booking Booking{
			get;
			set;
		}

		public override IXmlAnswer execute ()
		{
			Database.FlightRequest fr = new Database.FlightRequest();
			Database.PassengerRequest pr = new Database.PassengerRequest();
			Database.SeatRequest sr = new Database.SeatRequest();
			Database.ClassRequest cr = new Database.ClassRequest ();

			int classID = cr.fetchClassFromName (this.Booking.Seat.SeatClass.Name) [0].ID;
			int seatID = sr.fetchSeatFromClassAndNumber (class_: classID, number: this.Booking.Seat.Number) [0].ID;

			int passengerID = pr.fetchPassengerFromName(this.Booking.Passenger.Name)[0].ID;
			int flightID = fr.fetchFlightFromCodeAndStartDate(code: this.Booking.Flight.Code, startDate: this.Booking.Flight.StartDate)[0].ID;

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

