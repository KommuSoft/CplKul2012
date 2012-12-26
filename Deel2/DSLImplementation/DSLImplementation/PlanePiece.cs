using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Plane",TypeColors.Yellow)]
	public class PlanePiece : ZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Yellow;
			}
		}

		public PlanePiece ()
		{
		}
	}
}

