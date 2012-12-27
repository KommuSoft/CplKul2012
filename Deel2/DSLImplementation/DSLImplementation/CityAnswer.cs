using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("CityAnswer")]
	public class CityAnswer
	{
		
		public CityAnswer(){
		}
		
		public CityAnswer (List<City> Cities)
		{
				this.Cities = Cities;
		}
		
		[XmlArray("ListOfCities")]
		[XmlArrayItem("City")]
		public List<City> Cities{
			get;
			set;
		}	
	}
}

