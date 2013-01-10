using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class CityAnswer
	{
		public CityAnswer (List<City> Cities)
		{
			this.Cities = Cities;
		}

		public List<City> Cities{ get; set; }	
	}
}

