using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode
{
	public class AnswerGetSeats : IAnswer
	{
		public AnswerGetSeats (List<Seat> seats)
		{
			this.seats = seats;
		}

		public List<Seat> seats { get; set; }

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			throw new NotImplementedException();
		}
	}
}

