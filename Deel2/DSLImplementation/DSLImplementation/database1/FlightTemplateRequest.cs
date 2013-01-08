using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class FlightTemplateRequest : DatabaseRequest<FlightTemplate>
	{
		public FlightTemplateRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM flight_template";
		}
		
		public List<FlightTemplate> fetchTemplateFromCode(string code)
		{
			return fetchFromQuery(createQuery("code", code));
		}
	}
}

