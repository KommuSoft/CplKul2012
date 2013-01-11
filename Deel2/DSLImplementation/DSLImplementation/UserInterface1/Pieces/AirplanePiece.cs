using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airplane",TypeColors.BrightBlue)]
	public class AirplanePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override string Name {
			get {
				return "Airplane";
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightBlue;
			}
		}

		public AirplanePiece () : this(null,null) {}
		public AirplanePiece (string type,string code) {
			this.Table.AddKeyParserPair("type",type,Parsers.StringParser,Parsers.StringObjectParser);
			this.Table.AddKeyParserPair("code",type,Parsers.StringParser,Parsers.StringObjectParser);
		}

	}
}

