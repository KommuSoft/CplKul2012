using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Plane",TypeColors.BrightYellow)]
	public class PlanePiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		public override TypeColors TypeColors {
			get {
				return TypeColors.BrightYellow;
			}
		}

		public PlanePiece () {
			this.Table.AddParserPair(Parsers.StringParser,Parsers.StringObjectParser);
			this.Table.Add("Id","AAAA");
		}
	}
}

