using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	//The answer for the request of airports
	[XmlRoot("FlightAnswer")]
	public class AnswerGetFlights
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
		
	}
}

