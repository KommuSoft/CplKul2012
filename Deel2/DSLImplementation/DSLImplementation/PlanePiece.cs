using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Plane",TypeColors.Yellow)]
	public class PlanePiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override TypeColors TypeColors {
			get {
				return TypeColors.Yellow;
			}
		}

		public PlanePiece () {
			this.Table.Add("Id","AAAA");
		}
	}
}

