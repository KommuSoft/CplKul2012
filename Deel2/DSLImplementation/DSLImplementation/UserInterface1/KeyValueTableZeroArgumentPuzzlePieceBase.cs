using System;

namespace DSLImplementation.UserInterface {

	public abstract class KeyValueTableZeroArgumentPuzzlePieceBase<TKey,TValue> : KeyValueTablePuzzlePieceBase<TKey,TValue> {

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

