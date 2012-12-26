using System;
using Gdk;

namespace DSLImplementation.UserInterface {

	[AttributeUsage(AttributeTargets.Class)]
	public class PuzzlePieceAttribute : Attribute {

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
		public Pixbuf Icon {
			get {
				return KnownColors.GeneratePuzzlePiece(this.TypeColors,64);
			}
		}

		public PuzzlePieceAttribute (string piecename, TypeColors typeColors) {
			this.piecename = piecename;
			this.typeColors = typeColors;
		}

	}
}

