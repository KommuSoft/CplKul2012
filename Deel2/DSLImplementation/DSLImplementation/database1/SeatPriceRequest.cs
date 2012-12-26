using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class SeatPriceRequest : DatabaseRequest<SeatPrice>
	{
		public SeatPriceRequest () : base() {}

		protected override string createQuery (string column, int value)
		{
			throw new System.NotImplementedException ();
		}

		private string createQuery (List<string> columns, List<int> values)
		{
			string query = "SELECT * FROM seat_price WHERE ";

			for (int i=0; i<columns.Count; ++i) {
				query += columns[i];
				query += " = ";
				query += values[i];
				if(i < columns.Count - 1){
					query += " AND ";
				}
			}

			return query;
		}

		public List<SeatPrice> fetchSeatPriceFromSeatAndFlight (int seatID, int flightID)
		{
			List<string> columns = new List<string>{"seat", "flight"};
			List<int> values = new List<int>{seatID, flightID};

			return fetchFromQuery(createQuery(columns, values));
		}
	}
}

