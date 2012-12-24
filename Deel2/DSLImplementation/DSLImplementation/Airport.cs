using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Airport")]
	public class Airport
	{
		public Airport ()
		{
		}
		
		public Airport(String Name, String Code){
			this.Name = Name;
			this.Code = Code;
		}
		
		[XmlAttribute("Name")]
		public String Name {
			get;

			set;
		}
		
		[XmlAttribute("Code")]
		public String Code {
			get;

			set;
		}
		
	}
}

