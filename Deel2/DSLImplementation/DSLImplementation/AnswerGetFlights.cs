using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DSLImplementation.UserInterface;


namespace DSLImplementation.XmlRepresentation
{
	//The answer for the request of airports
	[XmlRoot("FlightAnswer")]
	public class AnswerGetFlights : IXmlAnswer
	{
		public AnswerGetFlights(){
		}
		
		public AnswerGetFlights (List<Flight> Flights)
		{
			this.Flights = Flights;
		}
		
		[XmlArray("ListOfFlights")]
		[XmlArrayItem("Flight")]
		public List<Flight> Flights{
			get;
			set;
		}	


		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			throw new NotImplementedException();
		}
		
	}
}

