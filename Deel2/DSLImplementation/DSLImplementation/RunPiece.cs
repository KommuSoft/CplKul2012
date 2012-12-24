using System.Collections.Generic;

namespace DSLImplementation.UserInterface {


	public class RunPiece : PuzzlePieceBase {

		private static TypeColors[] constraints = new TypeColors[] {TypeColors.Red};

		public override TypeColors[] TypeColorArguments {
			get {
				return constraints;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.White;
			}
		}
		
		public RunPiece () {}
		public RunPiece (params IPuzzlePiece[] pieces) : base(pieces) {}
		public RunPiece (ICollection<IPuzzlePiece> pieces) : base(pieces) {}

	}
}

