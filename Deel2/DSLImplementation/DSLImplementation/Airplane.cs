using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Airplane")]
	public class Airplane
	{
		public Airplane ()
		{
		}
		
		public Airplane (String Type, List<SeatClass> Seats){
			this.Type = Type;
			this.Seats = Seats;
		}
		
		[XmlAttribute("Type")]
		public String Type {
			get;
			set;
		}
		
		[XmlArray("ListOfSeats")]
		[XmlArrayItem("Seat")]
		public List<SeatClass> Seats{
			get;
			set;
		}	
		
	}
}

