using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation{
	public class Flight{
		public Flight (){
		}
		
		public Flight (String Name, String Code, Airline Airline){
			this.Name = Name;
			this.Code = Code;
			this.Airline = Airline;
		}		
		
		[XmlAttribute("Name")]
		public String Name{
			get;
			set;
		}
		
		[XmlAttribute("Code")]
		public String Code{
			get;
			set;
		}
		
		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}
		
		
	}
}

