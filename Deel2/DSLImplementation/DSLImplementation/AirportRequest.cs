using System;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("AirportRequest")]
	public class AirportRequest
	{
		public AirportRequest ()
		{
		}
		
		[XmlElement("City")]
		public City City{
			get { return this.city; }

			set { this.city = value; }
		}
		
	}
}
