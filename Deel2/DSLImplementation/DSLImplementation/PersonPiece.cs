using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Person",TypeColors.Green)]
	public class PersonPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override DSLImplementation.UserInterface.TypeColors TypeColors {
			get {
				return TypeColors.Green;
			}
		}

		public PersonPiece () {
		}

	}

}