using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Flight",TypeColors.BrightYellow)]
	public class FlightPiece : KeyValueTablePuzzlePieceBase {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Purple,TypeColors.Cyan};
		private static readonly string[] argumentNames = new string[] {"Template","Airline"};

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

		public FlightPiece (string name) {
			this.Table.AddKeyParserPair("name",name,Parsers.StringParser,Parsers.StringParser);
		}
	}
}

