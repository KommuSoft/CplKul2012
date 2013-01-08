using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Country",TypeColors.DarkGray)]
	public class CountryPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.DarkGray;
			}
		}

		public CountryPiece () {
			this.Table.Add("2-letter",null);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Za-z]{2}"));
			this.Table.Add("3-letter",null);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Za-z]{3}"));
			this.Table.Add("3-digit",null);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[0-9]{3}"));
			this.Table.Add("name",null);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.StringParser);
		}

	}

}