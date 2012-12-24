using System;

namespace DSLImplementation.Database
{
	public class Country
	{
		public int ID { get; set; }
		public string name { get; set; }

		public Country (int ID, string name)
		{
			this.ID = ID;
			this.name = name;
		}

		public override string ToString ()
		{
			return string.Format ("[Country: ID={0}, name={1}]", ID, name);
		}
	}
}

