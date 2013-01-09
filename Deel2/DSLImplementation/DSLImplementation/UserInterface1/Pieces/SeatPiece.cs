using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Seat",TypeColors.Orange)]
	public class SeatPiece : KeyValueTablePuzzlePieceBase {

		private static readonly string[] argumentNames = new string[] {"Class"};
		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.LightGray};

		public override string[] ArgumentNames {
			get {
				return base.ArgumentNames;
			}
		}
		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Orange;
			}
		}

		public SeatPiece () : this(null) {
		}
		public SeatPiece (object number) {
			this.Table.AddKeyParserPair("number",number,Parsers.StringParser,Parsers.Int32Parser);
		}

	}
}

