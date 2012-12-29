using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("City")]
	public class City
	{
		public City ()
		{
		}
		
		public City(String Name, Country Country){
			this.Name = Name;
		}

		[XmlAttribute("Name")]
		public String Name{
			get;
			set;
		}
		
		[XmlAttribute("Country")]
		public String Country{
			get;
			set;
		}		
		
	}
}

