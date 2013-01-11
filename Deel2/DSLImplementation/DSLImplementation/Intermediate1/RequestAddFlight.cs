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
			Database.FlightTemplateRequest ftr = new Database.FlightTemplateRequest ();

			if (this.Flight.StartAirport == null) {
				return new AnswerAdd("The start airport of the flights isn't set");
			}

			List<Database.Location> locations = lr.fetchLocationFromAirports (new Database.Airport (code: this.Flight.StartAirport.Code), new Database.Airport (code: this.Flight.DestinationAirport.Code));
			if (locations.Count () == 0) {
				Database.AirportRequest airportRequest = new Database.AirportRequest();
				List<Database.Airport> airports = airportRequest.fetchAirportFromCode(this.Flight.StartAirport.Code);
				if(airports.Count() == 0){
					return new AnswerAdd("Couldn't find the airport with code " + this.Flight.StartAirport.Code);
				}
				int airport1ID = airports[0].ID;

				airports = airportRequest.fetchAirportFromCode(this.Flight.DestinationAirport.Code);
				if(airports.Count() == 0){
					return new AnswerAdd("Couldn't find the airport with code " + this.Flight.DestinationAirport.Code);
				}
				int airport2ID = airports[0].ID;

				Database.Location location = new Database.Location(airport1ID, airport2ID, this.Flight.distance);
				try{
					location.insert();
				} catch(Exception e){
					return new AnswerAdd(e.Message);
				}
				locations = lr.fetchLocationFromAirports (new Database.Airport (code: this.Flight.StartAirport.Code), new Database.Airport (code: this.Flight.DestinationAirport.Code));
			}
			int locationID = locations [0].ID;

			List<Database.Airline> airlines = ar.fetchAirlineFromCode (this.Flight.Template.airline.Code);
			if (airlines.Count () == 0) {
				return new AnswerAdd ("Couldn't find the airline with code " + this.Flight.Template.airline.Code);
			}
			int airlineID = airlines [0].ID;

			List<Database.Airplane> airplanes = apr.fetchAirplaneFromCode (this.Flight.Airplane.Code);
			if (airplanes.Count () == 0) {
				return new AnswerAdd ("Couldn't find the airplane with code " + this.Flight.Airplane.Code);
			}
			int airplaneID = airplanes [0].ID;

			List<Database.FlightTemplate> templates = ftr.fetchTemplateFromAirlineAndDigits(airlineID, this.Flight.Template.digits);
			if (templates.Count () == 0) {
				return new AnswerAdd("Couldn't find the template from airline " + airlines[0].code + " with digits " + this.Flight.Template.digits);
			}
			int templateID =  templates [0].ID;

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

