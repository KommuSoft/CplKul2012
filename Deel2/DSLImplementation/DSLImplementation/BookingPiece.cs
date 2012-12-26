using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Booking",TypeColors.Red)]
	public class BookingPiece : PuzzlePieceBase {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Green,TypeColors.Purple,TypeColors.Yellow|TypeColors.Purple};

		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return 2;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Red;
			}
		}

		public BookingPiece ()
		{
		}
	}
}

