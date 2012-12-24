using System;
namespace DSLImplementation.XmlRepresentation{

	[XmlRoot("FlightRequest")]
	public class FlightRequest{

		public FlightRequest (){
		}
		
		public FlightRequest(Airport Airport1, Airport Airport2, Time Time, Company Company, Seat Seat){
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Time = Time;
			this.Company = Company;
			this.Seat = Seat;
		}

		[XmlElement("Airport1")]
		public Airport Airport1 {
			get { return this.airport1; }

			set { this.airport1 = value; }
		}
		
		[XmlElement("Airport2")]
		public Airport Airport2{
			get { return this.airport2; }

			set { this.airport2 = value; }
		}
		
		[XmlElement("Time")]
		public Time Time{
			get { return this.time; }

			set { this.time = value; }
		}
		
		[XmlElement("Company")]
		public Company Company{
			get { return this.company; }

			set { this.company = value; }
		}
		
		[XmlElement("Seat")]
		public Seat Seat{
			get { return this.seat; }

			set { this.seat = value; }
		}		
		
	}
}

