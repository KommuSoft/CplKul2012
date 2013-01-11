using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("City",TypeColors.Blue)]
	public class CityPiece : KeyValueTableZeroArgumentPuzzlePieceBase, ILocationPiece {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.DarkGray};
		private static readonly string[] argumentNames = new string[] {"Country"};

		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override string[] ArgumentNames {
			get {
				return argumentNames;
			}
		}
		public override TypeColors TypeColors {
			get {
				return TypeColors.Blue;
			}
		}

		public CityPiece () : this(null,null) {
		}
		public CityPiece (string name, CountryPiece cp) : base(cp) {
			this.Table.AddKeyParserPair("name",name,Parsers.StringParser,Parsers.StringParser);
		}
	}
}

