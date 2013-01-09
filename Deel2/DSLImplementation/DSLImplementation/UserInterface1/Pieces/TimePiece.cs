using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Time",TypeColors.BrightMagenta)]
	public class TimePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightMagenta;
			}
		}

		public TimePiece () {
			this.Table.Add("Timepoint",DateTime.Now);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.DateTimeParser);
		}

	}

}