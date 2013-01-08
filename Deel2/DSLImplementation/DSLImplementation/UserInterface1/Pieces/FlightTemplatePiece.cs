using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("FlightTemplate",TypeColors.Purple)]
	public class FlightTemplatePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

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

		public FlightTemplatePiece () {
			this.Table.AddKeyParserPair("code",Parsers.StringParser,Parsers.GenerateRegexMatchingParser(@"[A-Z]{2,3}"));
		}

	}

}