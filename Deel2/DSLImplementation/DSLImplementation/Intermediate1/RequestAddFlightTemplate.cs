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
			string airlineCode = "";
			string digits = "";
			Database.Util.split(this.FlightTemplate.Code, ref airlineCode, ref digits);

			Database.AirlineRequest ar = new Database.AirlineRequest ();
			List<Database.Airline> airlines = ar.fetchAirlineFromCode (airlineCode);
			if (airlines.Count () != 1) {
				return new AnswerAdd("A (unique) airline with code " + airlineCode + " couldn't be found");
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

