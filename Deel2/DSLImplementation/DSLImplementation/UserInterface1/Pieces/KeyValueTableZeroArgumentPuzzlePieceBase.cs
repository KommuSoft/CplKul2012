using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	public abstract class KeyValueTableZeroArgumentPuzzlePieceBase : KeyValueTablePuzzlePieceBase {

		private static TypeColors[] empty = new TypeColors[0x00];

		public override TypeColors[] TypeColorArguments {
			get {
				return empty;
			}
		}

		protected KeyValueTableZeroArgumentPuzzlePieceBase () : base() {
		}
		protected KeyValueTableZeroArgumentPuzzlePieceBase (IEnumerable<IPuzzlePiece> children) : base(children) {
		}
		protected KeyValueTableZeroArgumentPuzzlePieceBase (params IPuzzlePiece[] children) : base(children) {
		}

	}

}

