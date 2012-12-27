using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Booking",TypeColors.Red)]
	public class BookingPiece : PuzzlePieceBase {

		private static string[] argnames = new string[] {"Person","Flight","Seat"};
		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Green,TypeColors.Yellow,TypeColors.Brown};

		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return 1;
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

