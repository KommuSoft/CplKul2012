using System;
using System.Xml.Serialization;
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
			get;

			set;
		}
		
	}
}

