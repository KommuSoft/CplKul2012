using System;
using System.Collections.Generic;
using System.Linq;

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

			Console.WriteLine ("Info of airport 1 " + this.Flight.StartAirport.Code);

			List<Database.Location> locations = lr.fetchLocationFromAirports (new Database.Airport (code: this.Flight.StartAirport.Code), new Database.Airport (code: this.Flight.DestinationAirport.Code));
			if (locations.Count () == 0) {
				//TODO dit moet automatisch de locatie aanmaken
				return new AnswerAdd ("Couldn't find the location");
			}
			int locationID = locations [0].ID;

			List<Database.Airline> airlines = ar.fetchAirlineFromCode (this.Flight.Airline.Code);
			if (airlines.Count () == 0) {
				return new AnswerAdd ("Couldn't find the airline with code " + this.Flight.Airline.Code);
			}
			int airlineID = airlines [0].ID;

//			List<int> seats = new List<int> ();
//			foreach (Seat s in this.Flight.Airplane.Seats) {
//				int classID = cr.fetchClassFromName (s.SeatClass.Name) [0].ID;
//				seats.Add (sr.fetchSeatFromClassAndNumber (class_: classID, number: s.Number) [0].ID);
//			}

			List<Database.Airplane> airplanes = apr.fetchAirplaneFromCode (this.Flight.Airplane.Code);
			if (airplanes.Count () == 0) {
				return new AnswerAdd ("Couldn't find the airplane with code " + this.Flight.Airplane.Code);
			}
			int airplaneID = airplanes [0].ID;

			List<Database.FlightTemplate> templates = ftr.fetchTemplateFromCode (this.Flight.Template.Code);
			if (templates.Count () == 0) {
				return new AnswerAdd("Couldn't find the template with code " + this.Flight.Template.Code);
			}
			int templateID =  templates [0].ID;

			Console.WriteLine("BLABLA " + templates[0].code);

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

