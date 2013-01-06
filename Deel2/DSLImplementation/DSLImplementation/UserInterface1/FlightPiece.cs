using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Flight",TypeColors.Yellow)]
	public class FlightPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Yellow;
			}
		}

		public FlightPiece () {
			this.Table.AddParserPair(Parsers.StringParser,Parsers.StringParser);
			this.Table.Add("flightnumber","AAAA");
		}
	}
}

