using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Class",TypeColors.LightGray)]
	public class ClassPiece : ZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.LightGray;
			}
		}

		public ClassPiece () {
		}
	}
}

