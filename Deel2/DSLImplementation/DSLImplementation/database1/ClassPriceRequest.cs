using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class ClassPriceRequest : DatabaseRequest<ClassPrice>
	{
		public ClassPriceRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, class, price FROM class_price WHERE " + column + " = " + value;
		}

		public List<ClassPrice> fetchClassPriceFromID (int ID)
		{
			return fetchFromQuery(createQuery("id", ID));
		}
	}
}

