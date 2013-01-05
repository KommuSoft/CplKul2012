using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatPriceRequest : DatabaseRequest<SeatPrice>
	{
		public SeatPriceRequest () : base() {}

		protected override string createBase ()
		{
			return "SELECT * FROM seat_price";
		}

		public override List<SeatPrice> fetchFromID (int id)
		{
			//TODO dit zal nooit geimplementeerd worden
			throw new System.NotImplementedException ();
		}

		public List<SeatPrice> fetchSeatPriceFromSeatAndFlight (int seatID, int flightID)
		{
			List<string> columns = new List<string>{"seat", "flight"};
			List<object> values = new List<object>{seatID, flightID};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

