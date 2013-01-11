using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Flight",TypeColors.BrightYellow)]
	public class FlightPiece : KeyValueTablePuzzlePieceBase {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Magenta|TypeColors.Blue|TypeColors.LightGray,TypeColors.Magenta|TypeColors.Blue|TypeColors.LightGray,TypeColors.Purple,TypeColors.Cyan,TypeColors.BrightMagenta,TypeColors.BrightMagenta,TypeColors.BrightMagenta,TypeColors.BrightBlue};
		private static readonly string[] argumentNames = new string[] {"From","To","Template","Airline","Start","Stop","Stop same timezone","Airplane"};

		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override string[] ArgumentNames {
			get {
				return argumentNames;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightYellow;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return 0x06;
			}
		}

		public FlightPiece () : this (null) {
		}
		public FlightPiece (object distance) {
			this.Table.AddKeyParserPair("distance",distance,Parsers.StringParser,Parsers.Int32Parser);
		}

	}
}

