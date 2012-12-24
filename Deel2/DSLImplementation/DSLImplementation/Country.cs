using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Country")]
	public class Country
	{
		public Country ()
		{
		}
		
		public Country(String Name){
			this.Name = Name;
		}
		
		[XmlAttribute("Name")]
		public String Name{
			get;
			set;
		}
	}
}

