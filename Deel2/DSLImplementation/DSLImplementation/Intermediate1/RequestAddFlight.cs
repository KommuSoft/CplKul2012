using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestAddFlight : XmlRequestBase
	{
		public RequestAddFlight (Flight Flight){
			this.Flight = Flight;
		}

		public Flight Flight{ get; set; }

		public override IXmlAnswer execute ()
		{
			Database.LocationRequest lr = new Database.LocationRequest ();
			Database.AirlineRequest ar = new Database.AirlineRequest ();
			Database.AirplaneRequest apr = new Database.AirplaneRequest ();
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.ClassRequest cr = new Database.ClassRequest ();
			Database.FlightTemplateRequest ftr = new Database.FlightTemplateRequest ();

			int locationID = lr.fetchLocationFromAirports (new Database.Airport (name: this.Flight.StartAirport.Name), new Database.Airport (name: this.Flight.DestinationAirport.Name)) [0].ID;
			int airlineID = ar.fetchAirlineFromCode (this.Flight.Airline.Code) [0].ID;

			List<int> seats = new List<int> ();
			foreach (Seat s in this.Flight.Airplane.Seats) {
				int classID = cr.fetchClassFromName (s.SeatClass.Name) [0].ID;
				seats.Add (sr.fetchSeatFromClassAndNumber (class_: classID, number: s.Number) [0].ID);
			}

			int airplaneID = apr.fetchAirplaneFromCode(this.Flight.Airplane.Code)[0].ID;
			int templateID = ftr.fetchTemplateFromCode (this.Flight.Template.Code) [0].ID;

			Database.Flight flight = new Database.Flight (locationID, airlineID, this.Flight.StartDate, this.Flight.EndDate, airplaneID, templateID, this.Flight.TravelTime);

			AnswerAdd aa = new AnswerAdd ();

			try {
				flight.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}

	}
}

