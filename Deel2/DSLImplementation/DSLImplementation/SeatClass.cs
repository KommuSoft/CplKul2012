using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Class")]
	public class SeatClass
	{
		public SeatClass ()
		{
		}
		
		public SeatClass(String Name){
			this.Name = Name;
		}
		
		[XmlAttribute("Name")]
		public String Name {
			get;
			set;
		}
		
	}
}

