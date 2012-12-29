using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Time",TypeColors.Orange)]
	public class TimePiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

		public override DSLImplementation.UserInterface.TypeColors TypeColors {
			get {
				return TypeColors.Orange;
			}
		}

		public TimePiece ()
		{
		}

	}

}