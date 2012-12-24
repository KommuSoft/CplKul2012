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
		
		[XmlElement("City")]
		public Airport Airport{
			get;
			set;
		}	
		
	}
}

