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
			foreach (char c in code) {
				if (Char.IsLetter (c)) {
					airlineCode += c;
				} else if (Char.IsDigit (c)) {
					digits += c;
				}
			}

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

