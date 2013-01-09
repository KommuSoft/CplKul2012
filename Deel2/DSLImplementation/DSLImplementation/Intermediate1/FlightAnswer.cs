using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("FlightAnswer")]
	public class FlightAnswer
	{
		public FlightAnswer (List<Flight> Flights)
		{
			this.Flights = Flights;
		}
		
		[XmlArray("ListOfFlights")]
		[XmlArrayItem("Flights")]
		public List<Flight> Flights{
			get;
			set;
		}	
	}
}

