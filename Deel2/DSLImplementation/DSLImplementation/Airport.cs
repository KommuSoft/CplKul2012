using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Airport")]
	public class Airport
	{
		public Airport ()
		{
		}
		
		public Airport(String Name, String Code, City City, Country Country, List<Airline> Airlines){
			this.Name = Name;
			this.Code = Code;
			this.City = City;
			this.Country = Country;
			this.Airlines = Airlines;
		}
		
		[XmlAttribute("Name")]
		public String Name {
			get;
			set;
		}
		
		[XmlAttribute("Code")]
		public String Code {
			get;
			set;
		}
		
		[XmlElement("City")]
		public City City {
			get;
			set;
		}
		
		[XmlElement("Country")]
		public Country Country {
			get;
			set;
		}

		[XmlArray("ListOfAirlines")]
		[XmlArrayItem("Airline")]
		public List<Airline> Airlines{
			get;
			set;
		}		
		
	}
}

