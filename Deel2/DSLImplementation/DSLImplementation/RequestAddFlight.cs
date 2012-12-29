using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddFlight")]
	public class RequestAddFlight
	{
		
		public RequestAddFlight (){
		}
		
		public RequestAddFlight (Flight Flight){
			this.Flight = Flight;
		}
		
		[XmlElement("Flight")]
		public Flight Flight{
			get;
			set;
		}
		
	}
}

