using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirplane")]
	public class RequestAddAirplane
	{
		public RequestAddAirplane ()
		{
		}
		
		[XmlElement("Airplane")]
		public Airplane Airplane{
			get;
			set;
		}	
	}
}

