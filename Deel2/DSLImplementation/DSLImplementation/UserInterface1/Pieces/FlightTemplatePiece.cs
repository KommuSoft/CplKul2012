using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("FlightTemplate",TypeColors.Purple)]
	public class FlightTemplatePiece : KeyValueTablePuzzlePieceBase {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Cyan};
		private static readonly string[] argumentNames = new string[] {"airline"};

		public override string[] ArgumentNames {
			get {
				return argumentNames;
			}
		}
		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return 0x01;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}
		public override string Name {
			get {
				return "FlightTemplate";
			}
		}

		public FlightTemplatePiece () : this(null,null) {
		}
		public FlightTemplatePiece (AirlinePiece ap, string code) : base(ap) {
			this.Table.AddKeyParserPair("code",code,Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Z]{2,3}[0-9]{3}"));
		}

	}

}