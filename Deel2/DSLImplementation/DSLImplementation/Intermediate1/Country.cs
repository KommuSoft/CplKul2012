using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("Country")]
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

