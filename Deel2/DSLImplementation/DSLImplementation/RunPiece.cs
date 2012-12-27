using System.Collections.Generic;

namespace DSLImplementation.UserInterface {


	public class RunPiece : PuzzlePieceBase {

		private static TypeColors[] constraints = new TypeColors[] {TypeColors.Red};
		private static readonly string[] argnames = new string[] {"Query/Task"};

		public override TypeColors[] TypeColorArguments {
			get {
				return constraints;
			}
		}
		public override string[] ArgumentNames {
			get {
				return argnames;
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

