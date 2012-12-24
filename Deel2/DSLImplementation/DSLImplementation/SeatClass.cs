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
		
		public SeatClass(String Type){
			this.GetType = Type;
		}
		
		[XmlAttribute("Type")]
		public String type {
			get;
			set;
		}
		
	}
}

