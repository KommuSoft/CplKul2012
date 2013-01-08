using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Time",TypeColors.BrightBlue)]
	public class TimePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightBlue;
			}
		}

		public TimePiece () {
			this.Table.Add("Timepoint",DateTime.Now);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.DateTimeParser);
		}

	}

}