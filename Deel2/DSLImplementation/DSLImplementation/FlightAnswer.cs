using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("FlightAnswer")]
	public class FlightAnswer
	{
		public FlightAnswer (List<Airport> Flights)
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

