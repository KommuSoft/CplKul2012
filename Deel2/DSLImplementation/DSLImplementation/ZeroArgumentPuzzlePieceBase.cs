using System;

namespace DSLImplementation.UserInterface {

	public abstract class ZeroArgumentPuzzlePieceBase : PuzzlePieceBase {

		private static TypeColors[] empty = new TypeColors[0x00];

		public override TypeColors[] TypeColorArguments {
			get {
				return empty;
			}
		}

		protected ZeroArgumentPuzzlePieceBase () : base()
		{
		}

	}

}

