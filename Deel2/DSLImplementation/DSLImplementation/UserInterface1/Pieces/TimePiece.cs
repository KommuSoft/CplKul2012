using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Time",TypeColors.Orange)]
	public class TimePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override DSLImplementation.UserInterface.TypeColors TypeColors {
			get {
				return TypeColors.Orange;
			}
		}

		public TimePiece () {
			this.Table.Add("Timepoint",DateTime.Now);
			this.Table.AddParserPair(Parsers.StringParser,Parsers.DateTimeParser);
		}

	}

}