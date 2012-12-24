using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation{
	[XmlType("Company")]
	public class Company{
		public Company (){
		}
		
		public Company(String Name){
			this.Name = Name;
		}
		
		[XmlAttribute("Name")]
		public String Name {
			get;
			set;
		}
	}
}

