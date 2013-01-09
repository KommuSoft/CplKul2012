using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation{

	[XmlRoot("FlightRequest")]
	public class FlightRequest{

		public FlightRequest (){
		}
		
		public FlightRequest(Airport Airport1, Airport Airport2, DateTime Time, Airline Airline, SeatClass SeatClass){
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Time = Time;
			this.Airline = Airline;
			this.SeatClass = SeatClass;
		}

		[XmlElement("Airport1")]
		public Airport Airport1 {
			get;
			set;
		}
		
		[XmlElement("Airport2")]
		public Airport Airport2{
			get;
			set;
		}
		
		[XmlElement("Time")]
		public DateTime Time{
			get;
			set;
		}
		
		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}
		
		[XmlElement("Class")]
		public SeatClass SeatClass{
			get;
			set;
		}		
		
	}
}

