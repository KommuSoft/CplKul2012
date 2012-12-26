using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airport",TypeColors.Purple)]
	public class AirportPiece : ZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}

		public AirportPiece ()
		{
		}
	}
}

