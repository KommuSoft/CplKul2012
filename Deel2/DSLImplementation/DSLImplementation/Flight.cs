using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation{
	public class Flight{
		public Flight (){
		}
		
		public Flight (String Name, String Code){
			this.Name = Name;
			this.Code = Code;
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
	}
}

