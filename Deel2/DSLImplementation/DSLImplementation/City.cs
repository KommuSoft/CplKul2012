using System;
namespace DSLImplementation
{
	[XmlType("City")]
	public class City
	{
		public City ()
		{
		}

		[XmlAttribute("Name")]
		public String Name{
			get { return this.name; }

			set { this.name = value; }
		}
		
	}
}

