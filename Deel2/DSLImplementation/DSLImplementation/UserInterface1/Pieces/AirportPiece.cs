using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airport",TypeColors.Magenta)]
	public class AirportPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Magenta;
			}
		}

		public AirportPiece ()
		{
		}
	}
}