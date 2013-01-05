using System;
using System.Data;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatPrice : DatabaseTable
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

		public override string tableName ()
		{
			return "seat_price";
		}

		public override string ToString ()
		{
			return string.Format ("[SeatPrice: seat={0}, flight={1}, price={2}]", seat, flight, price);
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (price < 0) {
				return makeExceptionMessage(out exceptionMessage, "The price of the seat is invalid");
			}

			return validFlight(flight, out exceptionMessage) && validSeat(seat, out exceptionMessage);
		}

		public override void insert(){
			List<string> columns = new List<string>{"seat", "flight", "price"};
			List<object> values = new List<object>{seat, flight, price};

			base.insert(columns, values);
		}
	}
}

