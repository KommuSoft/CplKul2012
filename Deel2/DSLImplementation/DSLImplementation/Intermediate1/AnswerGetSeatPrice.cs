using System;
using DSLImplementation.UserInterface;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class AnswerGetSeatPrice : IAnswer
	{
		public AnswerGetSeatPrice (SeatPrice seatPrice)
		{
			this.seatPrice = seatPrice;
		}

		public SeatPrice seatPrice { get; set; }

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			throw new NotImplementedException();
		}
	}
}

