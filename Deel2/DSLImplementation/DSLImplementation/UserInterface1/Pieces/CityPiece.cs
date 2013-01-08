using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("City",TypeColors.Blue)]
	public class CityPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Blue;
			}
		}

		public CityPiece () {
			this.Table.Add("name",null);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.StringParser);
		}
	}
}

