using System;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("CityRequest")]
	public class CityRequest
	{
		public CityRequest ()
		{
		}
		[XmlElement("Country")]
		public Country Country {
			get { return this.country; }

			set { this.country = value; }
		}
		
	}
}

