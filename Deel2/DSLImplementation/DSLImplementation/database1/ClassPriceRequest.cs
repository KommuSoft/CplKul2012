using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class ClassPriceRequest : DatabaseRequest
	{
		public ClassPriceRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			return "SELECT id, class, price FROM class_price WHERE " + column + " = " + value;
		}
		
		private ClassPrice createClassPrice (IDataReader reader)
		{
			int ID = reader.GetInt32(reader.GetOrdinal("id"));
			int class_ = reader.GetInt32(reader.GetOrdinal("class"));
			decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
			return new ClassPrice(ID: ID, price: price, class_: class_);
		}

		public ClassPrice fetchClassPriceFromID (int ID)
		{
			
			IDataReader reader = db.CreateCommand(createQuery("id", ID));
			
			reader.Read();
			ClassPrice classPrice = createClassPrice(reader);
			
			reader.Close();
			reader = null;
			db.CloseCommand();
			
			return classPrice;
		}
	}
}

