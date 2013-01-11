using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class FlightTemplateRequest : DatabaseRequest<FlightTemplate>
	{
		public FlightTemplateRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM flight_template";
		}
		
		public List<FlightTemplate> fetchTemplateFromCode (string code)
		{
			if (code == null) {
				throw new InvalidObjectException("The code of the flight template isn't set");
			}

			string airlineCode = "";
			string digits = "";
			Util.split(code, ref airlineCode, ref digits);

			AirlineRequest ar = new AirlineRequest ();
			List<Airline> airlines = ar.fetchAirlineFromCode (airlineCode);
			if (airlines.Count () != 0) {
				throw new InvalidObjectException("No airline found with code " + airlineCode);
			}
			int airlineID = airlines[0].ID;

			return fetchTemplateFromAirlineAndDigits(airlineID, digits);
		}

		public List<FlightTemplate> fetchTemplateFromAirlineAndDigits (int airline, string digits)
		{
			List<string> columns = new List<string>{"airline", "digits"};
			List<object> values = new List<object>{airline, digits};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

