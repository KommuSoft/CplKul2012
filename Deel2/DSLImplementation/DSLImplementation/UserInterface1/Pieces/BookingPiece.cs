using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Booking",TypeColors.Red)]
	public class BookingPiece : PuzzlePieceBase {

		private static string[] argnames = new string[] {"Person","Flight","Seat"};
		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Green,TypeColors.BrightYellow,TypeColors.Orange};

		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override string[] ArgumentNames {
			get {
				return argnames;
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

