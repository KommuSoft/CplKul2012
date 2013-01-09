using System;

namespace DSLImplementation.UserInterface {

	public class SucceedFailPiece : ZeroArgumentPuzzlePieceBase {

		private readonly string name;

		public override string Name {
			get {
				return this.name;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}

		public SucceedFailPiece () : this("Done") {
		}
		public SucceedFailPiece (string name) {
			this.name = name;
		}

	}

}