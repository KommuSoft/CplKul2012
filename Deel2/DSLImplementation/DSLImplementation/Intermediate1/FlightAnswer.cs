using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class FlightAnswer
	{
		public FlightAnswer (List<Flight> Flights)
		{
			this.Flights = Flights;
		}

		public List<Flight> Flights{ get; set; }	
	}
}

