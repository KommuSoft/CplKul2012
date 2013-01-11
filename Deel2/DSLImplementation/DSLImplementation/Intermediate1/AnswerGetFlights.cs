using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;


namespace DSLImplementation.IntermediateCode
{
	//The answer for the request of airports
	public class AnswerGetFlights : IAnswer
	{
		public AnswerGetFlights (List<Flight> Flights)
		{
			this.Flights = Flights;
		}

		public List<Flight> Flights{ get; set; }	

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			foreach(Flight f in Flights) {
				yield return new FlightPiece(new AirportPiece(f.StartAirport.Name,f.StartAirport.Code),
				                             new AirportPiece(f.DestinationAirport.Name,f.DestinationAirport.Code),
				                             new FlightTemplatePiece(new AirlinePiece(f.Template.airline.Name,f.Template.airline.Code),f.Template.Code),
				                             new TimePiece(f.StartDate),
				                             new TimePiece(f.EndDate),
				                             new TimePiece(f.StartDate+new TimeSpan(f.TravelTime.Ticks)),
				                             new AirplanePiece(f.Airplane.Type,f.Airplane.Code));
			}
		}
		
	}
}

