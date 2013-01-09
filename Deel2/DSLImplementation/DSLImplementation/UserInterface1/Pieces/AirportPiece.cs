using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airport",TypeColors.Magenta)]
	public class AirportPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Magenta;
			}
		}

		public AirportPiece () : this(null,null) {}
		public AirportPiece (string name, string code) {
			this.Table.AddKeyParserPair("name",name,Parsers.StringParser,Parsers.StringObjectParser);
			this.Table.AddKeyParserPair("code",code,Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Z]{3}"));
		}
	}
}