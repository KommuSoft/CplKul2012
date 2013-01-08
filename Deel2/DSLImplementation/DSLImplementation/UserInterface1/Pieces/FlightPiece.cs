using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Flight",TypeColors.BrightYellow)]
	public class FlightPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightYellow;
			}
		}

		public FlightPiece () {
			this.Table.AddParserPair(Parsers.StringParser,Parsers.StringParser);
			this.Table.Add("flightnumber","AAAA");
		}
	}
}

