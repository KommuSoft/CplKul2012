using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("City")]
	public class Country
	{
		public Country ()
		{
		}
		
		[XmlAttribute("Name")]
		public String Name{
			get;

			set;
		}
	}
}

