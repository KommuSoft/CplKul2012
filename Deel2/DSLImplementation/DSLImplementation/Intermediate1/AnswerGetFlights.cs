using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;


namespace DSLImplementation.IntermediateCode
{
	//The answer for the request of airports
	public class AnswerGetFlights : IXmlAnswer
	{
		public AnswerGetFlights (List<Flight> Flights)
		{
			this.Flights = Flights;
		}

		public List<Flight> Flights{ get; set; }	

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			throw new NotImplementedException();
		}
		
	}
}

