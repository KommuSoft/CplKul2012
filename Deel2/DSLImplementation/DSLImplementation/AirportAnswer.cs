using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	//The answer for the request of airports
	[XmlRoot("AirportAnswer")]
	public class AirportAnswer
	{
		public AirportAnswer(){
		}
		
		public AirportAnswer (List<Airport> Airports)
		{
			this.Airports = Airports;
		}
		
		[XmlArray("ListOfAirports")]
		[XmlArrayItem("Airport")]
		public List<Airport> Airports{
			get;
			set;
		}	
		
	}
}

