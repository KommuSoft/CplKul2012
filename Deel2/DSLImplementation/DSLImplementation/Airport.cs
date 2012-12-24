using System;
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
			get { return this.name; }

			set { this.name = value; }
		}
		
		[XmlAttribute("Code")]
		public String Code {
			get { return this.code; }

			set { this.code = value; }
		}
		
	}
}

