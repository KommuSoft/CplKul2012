using System;

namespace DSLImplementation.UserInterface {

	public class PuzzlePieceAttribute {

		private readonly string piecename;
		private readonly TypeColors typeColors;

		public string PieceName {
			get {
				return this.piecename;
			}
		}
		public TypeColors TypeColors {
			get {
				return this.typeColors;
			}
		}

		public PuzzlePieceAttribute (string piecename, TypeColors typeColors) {
			this.piecename = piecename;
			this.typeColors = typeColors;
		}

	}
}

