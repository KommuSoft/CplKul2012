using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("FlightTemplate")]
	public class FlightTemplate
	{
		public FlightTemplate ()
		{
		}
		
		[XmlAttribute("Code")]
		public String Code{
			get;
			set;
		}
	}
}

