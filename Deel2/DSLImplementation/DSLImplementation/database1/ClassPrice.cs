using System;

namespace DSLImplementation.Database
{
	public class ClassPrice
	{
		public int ID { get; set; }
		public int class_ { get; set; }
		public decimal price { get; set; }

		public ClassPrice (int ID, int class_, decimal price)
		{
			this.ID = ID;
			this.class_ = class_;
			this.price = price;
		}

		public override string ToString ()
		{
			return string.Format ("[ClassPrice: ID={0}, classID={1}, price={2}]", ID, class_, price);
		}
	}
}
