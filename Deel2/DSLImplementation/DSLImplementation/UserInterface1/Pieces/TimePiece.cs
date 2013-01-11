using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Time",TypeColors.BrightMagenta)]
	public class TimePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightMagenta;
			}
		}

		public TimePiece () : this(DateTime.Now)
		{
		}
		public TimePiece (DateTime datetime) {
			this.Table.AddKeyParserPair("time",datetime,Parsers.StringParser,Parsers.DateTimeParser);
		}

	}

}