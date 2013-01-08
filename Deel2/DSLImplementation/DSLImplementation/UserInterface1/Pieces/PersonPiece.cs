using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Passenger",TypeColors.Green)]
	public class PassengerPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Green;
			}
		}

		public PassengerPiece () {
		}

	}

}