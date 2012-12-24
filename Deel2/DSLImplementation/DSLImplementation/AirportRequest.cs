using System;
using System.Xml.Serialization;
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
			get;

			set;
		}
		
	}
}

