using System;

namespace DSLImplementation.UserInterface {

	public class LinkPiece : ZeroArgumentPuzzlePieceBase {

		private readonly IPuzzlePiece piece;

		public override string Name {
			get {
				return string.Empty;
			}
		}
		public IPuzzlePiece Piece {
			get {
				return this.piece;
			}
		}

		public override TypeColors TypeColors {
			get {
				return this.piece.TypeColors;
			}
		}

		public LinkPiece (IPuzzlePiece piece) {
			this.piece = piece;
		}

	}

}