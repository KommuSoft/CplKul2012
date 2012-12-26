using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Person",TypeColors.Green)]
	public class PersonPiece : ZeroArgumentPuzzlePieceBase {

		public override DSLImplementation.UserInterface.TypeColors TypeColors {
			get {
				return TypeColors.Green;
			}
		}

		public PersonPiece () {
		}

	}

}