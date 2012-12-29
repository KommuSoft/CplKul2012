using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Airline")]
	public class Airline{
		public Airline (){
		}
		
		public Airline(String Name){
			this.Name = Name;
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

