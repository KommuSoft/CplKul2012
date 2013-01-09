using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlType("Airline")]
	public class Airline{
		public Airline (){
		}
		
		public Airline(String Name, string Code){
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

