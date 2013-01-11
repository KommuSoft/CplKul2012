using System;

namespace DSLImplementation.UserInterface {

	public class SucceedFailPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		private readonly string name;
		private readonly string message;

		public override string Name {
			get {
				return this.name;
			}
		}
		private string Message {
			get {
				return this.message;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Purple;
			}
		}

		public SucceedFailPiece () : this("Done") {
		}
		public SucceedFailPiece (string name) : this(name,string.Empty) {}
		public SucceedFailPiece (string name, string message) {
			this.name = name;
			this.message = message;
			this.Table.AddKeyParserPair("message",message,Parsers.StringParser,Parsers.StringObjectParser);
		}
		public SucceedFailPiece (Exception e) : this("fail",e.Message) {}

	}

}