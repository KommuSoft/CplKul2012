using System;
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
			get { return this.name; }

			set { this.name = value; }
		}
	}
}
