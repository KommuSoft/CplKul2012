using System;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	public class UnableToBindException : Exception {

		private readonly string key;
		private readonly IPuzzlePiece piece;

		public string Key {
			get {
				return key;
			}
		}
		public IPuzzlePiece Piece {
			get {
				return piece;
			}
		}
		public override string Message {
			get {
				return string.Format("The pattern requires that the {0} contains a value for {1}",piece.GetType().Name,key);
			}
		}

		public UnableToBindException (string key, IPuzzlePiece piece) {
			this.key = key;
			this.piece = piece;
		}

	}
}

