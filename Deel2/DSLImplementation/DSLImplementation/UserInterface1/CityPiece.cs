using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("City",TypeColors.Purple)]
	public class CityPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}

		public CityPiece ()
		{
		}
	}
}

