using System;
namespace DSLImplementation.IntermediateCode
{
	public class Flight{

		public Flight (FlightTemplate Template, DateTime StartDate)
		{
			this.Template = Template;
			this.StartDate = StartDate;
		}

		public Flight (FlightTemplate Template, DateTime StartDate, DateTime EndDate, Airport StartAirport, Airport DestinationAirport, Airplane Airplane, int distance) :
			this(Template, StartDate, EndDate, StartAirport, DestinationAirport, Airplane)
		{
			this.distance = distance;
		}

		public Flight (FlightTemplate Template, DateTime StartDate, DateTime EndDate, Airport StartAirport, Airport DestinationAirport, Airplane Airplane){
			this.Template = Template;
			this.StartDate = StartDate;
			this.EndDate = EndDate;
			this.StartAirport = StartAirport;
			this.DestinationAirport = DestinationAirport;
			this.Airplane = Airplane;
		}		

		public String Name ()
		{
			return Template.Code + StartDate;
		}

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public TimeSpan TravelTime {
			get{
				if(this.travelTime == default(TimeSpan)){
					this.travelTime = EndDate.Subtract(StartDate);
				}
				return this.travelTime;
			}
			set{
				this.travelTime = value;
			}}
		private TimeSpan travelTime;
		public Airport StartAirport { get; set; }
		public Airport DestinationAirport { get; set; }
		public Airplane Airplane { get; set; }
		public FlightTemplate Template { get; set; }
		public int distance { get; set; }
	}
}

