using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Person",TypeColors.Green)]
	public class PersonPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override DSLImplementation.UserInterface.TypeColors TypeColors {
			get {
				return TypeColors.Green;
			}
		}

		public PersonPiece () {
		}

	}

}