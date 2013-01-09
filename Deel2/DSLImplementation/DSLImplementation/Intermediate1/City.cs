using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlType("City")]
	public class City
	{
		public City ()
		{
		}
		
		public City(String Name, Country Country){
			this.Name = Name;
			this.Country = Country;
		}

		[XmlAttribute("Name")]
		public String Name{
			get;
			set;
		}
		
		[XmlElement("Country")]
		public Country Country{
			get;
			set;
		}		
		
	}
}

