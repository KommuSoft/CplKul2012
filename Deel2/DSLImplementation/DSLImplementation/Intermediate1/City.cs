using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	public class City
	{
		public City(String Name, Country Country){
			this.Name = Name;
			this.Country = Country;
		}

		public String Name{ get; set; }
		public Country Country{ get; set; }	
	}
}

