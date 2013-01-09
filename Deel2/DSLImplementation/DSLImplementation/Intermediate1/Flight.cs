using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode{
	public class Flight{
		public Flight (){
		}
		
		public Flight (FlightTemplate Template, Airline Airline, DateTime StartDate, DateTime EndDate, Airport StartAirport, Airport DestinationAirport, Airplane Airplane){
			this.Template = Template;
			this.Airline = Airline;
			this.StartDate = StartDate;
			this.EndDate = EndDate;
			this.StartAirport = StartAirport;
			this.DestinationAirport = DestinationAirport;
			this.Airplane = Airplane;
		}		
		
		[XmlAttribute("Name")]
		public String Name{
			get;
			set;
		}
		
		[XmlAttribute("Code")]
		public String Code{
			get;
			set;
		}
		
		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime TravelTime { get; set; }
		public Airport StartAirport { get; set; }
		public Airport DestinationAirport { get; set; }
		public Airplane Airplane { get; set; }
		public FlightTemplate Template { get; set; }
	}
}

