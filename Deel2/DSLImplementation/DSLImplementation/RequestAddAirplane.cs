using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirplane")]
	public class RequestAddAirplane
	{
		public RequestAddAirplane (){
		}
		
		public RequestAddAirplane (Airplane Airplane){
			this.Airplane = Airplane;
		}		
		
		[XmlElement("Airplane")]
		public Airplane Airplane{
			get;
			set;
		}	
	}
}

