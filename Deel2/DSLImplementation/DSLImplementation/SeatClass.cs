using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	
	//PJTODO: Hier moet er dan mss nog iets van prijs bijhoren ofzo, 
	//aangezien de prijs vastgekoppeld is aan de klasse
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

