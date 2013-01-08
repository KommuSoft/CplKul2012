using System;

namespace DSLImplementation.UserInterface {

	public abstract class KeyValueTableZeroArgumentPuzzlePieceBase : KeyValueTablePuzzlePieceBase {

		private static TypeColors[] empty = new TypeColors[0x00];

		public override TypeColors[] TypeColorArguments {
			get {
				return empty;
			}
		}

		protected KeyValueTableZeroArgumentPuzzlePieceBase () : base()
		{
		}

	}

}

