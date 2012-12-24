using System;

namespace DSLImplementation.Database
{
	public class Class
	{
		public int ID { get; set; }
		public string name { get; set; }

		public Class (int ID, string name)
		{
			this.ID = ID;
			this.name = name;
		}

		public override string ToString ()
		{
			return string.Format ("[Class: ID={0}, name={1}]", ID, name);
		}
	}
}

