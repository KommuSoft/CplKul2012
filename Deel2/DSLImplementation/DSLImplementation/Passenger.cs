using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Passenger")]
	public class Passenger
	{
		public Passenger ()
		{
		}
		
		public Passenger (String Name){
			this.Name = Name;
		}
		
		[XmlAttribute("Name")]
		public String Name {
			get;
			set;
		}
		
	}
}
