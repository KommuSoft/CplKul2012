using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Class",TypeColors.LightGray)]
	public class ClassPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.LightGray;
			}
		}

		public ClassPiece () : this(null) {}
		public ClassPiece (string name) {
			this.Table.AddKeyParserPair("name",name,Parsers.StringParser,Parsers.StringObjectParser);
		}
	}
}

