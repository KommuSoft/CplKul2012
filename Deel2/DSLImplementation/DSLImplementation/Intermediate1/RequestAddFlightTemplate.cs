using System;
using System.Collections.Generic;
using System.Linq;


namespace DSLImplementation.IntermediateCode
{
	public class RequestAddFlightTemplate : XmlRequestBase
	{
		public RequestAddFlightTemplate (FlightTemplate FlightTemplate){
			this.FlightTemplate = FlightTemplate;
		}

		public FlightTemplate FlightTemplate{ get; set; }		

		public override IAnswer execute ()
		{
			Database.AirlineRequest ar = new Database.AirlineRequest ();
			List<Database.Airline> airlines = ar.fetchAirlineFromCode (this.FlightTemplate.airline.Code);
			if (airlines.Count () != 0) {
				return new AnswerAdd("The airline with code " + this.FlightTemplate.airline.Code + " couldn't be found");
			}
			int airlineID = airlines[0].ID;

			Database.FlightTemplate template = new Database.FlightTemplate(airlineID, this.FlightTemplate.digits);
			AnswerAdd aa = new AnswerAdd();

			try{
				template.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}


	}
}

