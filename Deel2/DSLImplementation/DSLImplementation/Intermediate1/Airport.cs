using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class Airport
	{
	
		public Airport (string code)
		{
			this.Code = code;
		}

		public Airport(String Name, String Code, City City, List<Airline> Airlines = null){
			this.Name = Name;
			this.Code = Code;
			this.City = City;
			this.Airlines = Airlines;
		}

		public String Name { get; set; }
		public String Code { get; set; }
		public City City { get; set; }
		public List<Airline> Airlines{ get; set; }
	}
}

