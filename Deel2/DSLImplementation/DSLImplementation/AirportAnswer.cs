using System;
namespace DSLImplementation
{
	//The answer for the request of airports
	[XmlRoot("AirportAnswer")]
	public class AirportAnswer
	{
		public AirportAnswer ()
		{
		}
		
		[XmlArray("ListOfAirports")]
		[XmlArrayItem("Airport")]
		public List<Airport> Airport{
			get;
			set;
		}	
		
	}
}

