using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode
{
	//The answer for the request of airports
	public class AnswerGetAirports : IAnswer
	{
		public AnswerGetAirports (List<Airport> Airports)
		{
			this.Airports = Airports;
		}

		public List<Airport> Airports{ get; set; }	

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces() {
			foreach(Airport ap in Airports) {
				yield return new AirportPiece(ap.Name,ap.Code);
			}
		}
	}
}

