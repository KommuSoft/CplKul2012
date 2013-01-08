using System;
using DSLImplementation.UserInterface;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airline",TypeColors.Cyan)]
	public class AirlinePiece : ZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Cyan;
			}
		}
	
		public AirlinePiece () {
		}
	}
}

