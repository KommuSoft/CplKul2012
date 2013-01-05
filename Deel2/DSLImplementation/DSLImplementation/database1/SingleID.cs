using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public abstract class SingleID : DatabaseTable
	{
		private bool hasID = false;
		private int id;
		
		public int ID {
			get {
				return id;
			}
			set{
				hasID = true;
				id = value;
			}
		}
	
		protected override void insert (List<string> columns, List<object> values)
		{
			if (hasID) {
				columns.Insert(0, "id");
				values.Insert(0, ID);
			}

			base.insert(columns, values);
		}
	}
}

