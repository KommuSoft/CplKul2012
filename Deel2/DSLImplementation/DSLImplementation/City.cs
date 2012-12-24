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

		[XmlAttribute("Name")]
		public String Name{
			get;

			set;
		}
		
	}
}

