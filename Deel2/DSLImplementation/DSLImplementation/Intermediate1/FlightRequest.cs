using System;
namespace DSLImplementation.IntermediateCode
{
	public class FlightRequest{		
		public FlightRequest(Airport Airport1, Airport Airport2, DateTime Time, Airline Airline, SeatClass SeatClass){
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Time = Time;
			this.Airline = Airline;
			this.SeatClass = SeatClass;
		}

		public Airport Airport1 { get; set; }	
		public Airport Airport2 { get; set; }	
		public DateTime Time { get; set; }	
		public Airline Airline { get; set; }	
		public SeatClass SeatClass{ get; set; }		
		
	}
}

