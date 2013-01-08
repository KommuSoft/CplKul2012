using System;

namespace DSLImplementation.UserInterface {

	public class SucceedFailPiece : ZeroArgumentPuzzlePieceBase {

		public override string Name {
			get {
				return "Done";
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}

		public SucceedFailPiece () {
		}

	}

}