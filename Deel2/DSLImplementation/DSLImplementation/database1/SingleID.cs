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
	
		protected override int insert (List<string> columns, List<object> values)
		{
			if (hasID) {
				columns.Insert(0, "id");
				values.Insert(0, ID);
			}

			return base.insert(columns, values);
		}
	}
}

