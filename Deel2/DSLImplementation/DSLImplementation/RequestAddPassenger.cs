using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddPassenger")]
	public class RequestAddPassenger
	{
		public RequestAddPassenger (){
		}
		
		public RequestAddPassenger (Passenger Passenger){
			this.Passenger = Passenger;
		}
		
		[XmlElement("Passenger")]
		public Passenger Passenger{
			get;
			set;
		}	
		
	}
}

