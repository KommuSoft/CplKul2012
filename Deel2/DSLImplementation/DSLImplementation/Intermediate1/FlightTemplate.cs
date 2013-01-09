using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlType("FlightTemplate")]
	public class FlightTemplate
	{
		public FlightTemplate (string Code) {
			this.Code = Code;
		}
		
		[XmlAttribute("Code")]
		public String Code{
			get;
			set;
		}
	}
}

