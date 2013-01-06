using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Seat",TypeColors.Orange)]
	public class SeatPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,decimal> {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Orange;
			}
		}

		public SeatPiece () {

		}

	}
}

