using System;
using System.Data;

namespace DSLImplementation.Database
{
	public class SeatPrice
	{
		public int seat { get; set; }
		public int flight { get; set; }
		public decimal price { get; set; }

		public SeatPrice (int seat, int flight, decimal price)
		{
			this.seat = seat;
			this.flight = flight;
			this.price = price;
		}

		public SeatPrice (IDataReader reader)
		{
			seat = reader.GetInt32(reader.GetOrdinal("seat"));
			flight = reader.GetInt32(reader.GetOrdinal("flight"));
			price = reader.GetDecimal(reader.GetOrdinal("price"));
		}

		public override string ToString ()
		{
			return string.Format ("[SeatPrice: seat={0}, flight={1}, price={2}]", seat, flight, price);
		}
	}
}

