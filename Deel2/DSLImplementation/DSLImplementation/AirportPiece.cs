using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airport",TypeColors.Purple|TypeColors.Blue)]
	public class AirportPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple|TypeColors.Blue;
			}
		}

		public AirportPiece ()
		{
		}
	}
}

