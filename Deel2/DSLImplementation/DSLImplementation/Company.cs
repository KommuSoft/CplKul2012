using System;
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
			get { return this.name; }

			set { this.name = value; }
		}
	}
}

