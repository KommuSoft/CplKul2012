using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddSeatClass")]
	public class RequestAddSeatClass : XmlRequestBase
	{
		public RequestAddSeatClass (){
		}
		
		public RequestAddSeatClass (SeatClass SeatClass){
			this.SeatClass = SeatClass;
		}
		
		[XmlElement("SeatClass")]
		public SeatClass SeatClass{
			get;
			set;
		}	
		
	}
}

