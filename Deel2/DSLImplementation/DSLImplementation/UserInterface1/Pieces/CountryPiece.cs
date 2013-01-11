using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Country",TypeColors.DarkGray)]
	public class CountryPiece : KeyValueTableZeroArgumentPuzzlePieceBase, ILocationPiece {

		public override TypeColors TypeColors {
			get {
				return TypeColors.DarkGray;
			}
		}

		public CountryPiece () : this(null) {}
		public CountryPiece (string name) {
			this.Table.AddKeyParserPair("name",name,Parsers.StringParser,Parsers.StringParser);
		}

	}

}