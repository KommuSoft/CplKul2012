using System;
using System.Xml.Serialization;
//PJTODO: Er moet hier mss nog een code-attribuut bij afgaande op de opgave op pg. 2
namespace DSLImplementation.XmlRepresentation{
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

