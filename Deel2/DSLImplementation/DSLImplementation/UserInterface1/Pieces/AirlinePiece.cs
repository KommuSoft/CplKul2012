using System;
using DSLImplementation.UserInterface;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Airline",TypeColors.Cyan)]
	public class AirlinePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Cyan;
			}
		}
	
		public AirlinePiece () {
			this.Table.AddKeyParserPair("name",Parsers.StringParser,Parsers.StringObjectParser);
			this.Table.AddKeyParserPair("code",Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Z]{2,3}"));
		}
	}
}

