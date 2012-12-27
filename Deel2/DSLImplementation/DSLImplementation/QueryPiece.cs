using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Query",TypeColors.Red)]
	public class QueryPiece : PuzzlePieceBase {

		private TypeColors[] arguments = new TypeColors[0x01] {TypeColors.All};

		public override TypeColors TypeColors {
			get {
				return TypeColors.Red;
			}
		}
		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}

		public QueryPiece () {

		}

	}
}

