using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	
	[XmlType("Seat")]
	public class Seat
	{
		public Seat (){
		}
		
		public Seat(SeatClass SeatClass, int Number){
			this.SeatClass = SeatClass;
			this.Number = Number;
		}
		
		[XmlElement("SeatClass")]
		public SeatClass SeatClass {
			get;
			set;
		}
		
		[XmlAttribute("Number")]
		public int Number {
			get;
			set;
		}		
	}
}

