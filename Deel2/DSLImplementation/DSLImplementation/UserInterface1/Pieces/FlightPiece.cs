using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Flight",TypeColors.BrightYellow)]
	public class FlightPiece : KeyValueTablePuzzlePieceBase {

		private static readonly TypeColors[] arguments = new TypeColors[] {TypeColors.Magenta|TypeColors.Blue|TypeColors.DarkGray,TypeColors.Magenta|TypeColors.Blue|TypeColors.DarkGray,TypeColors.Purple,TypeColors.BrightMagenta,TypeColors.BrightMagenta,TypeColors.BrightMagenta,TypeColors.BrightBlue};
		private static readonly string[] argumentNames = new string[] {"from","to","template","start","stop local","stop","plane"};

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
				return TypeColors.BrightYellow;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return this.NumberOfArguments;
			}
		}

		public FlightPiece () : this (null,null,null,null,null,null,null,null) {
		}
		public FlightPiece (object distance, AirportPiece frm, AirportPiece to, FlightTemplatePiece tmplt, TimePiece tpsa, TimePiece tpso, TimePiece tsls, AirplanePiece airp) : base() {
			this.Table.AddKeyParserPair("distance",distance,Parsers.StringParser,Parsers.Int32Parser);
			this[0x00] = frm;
			this[0x01] = to;
			this[0x02] = tmplt;
			this[0x03] = tpsa;
			this[0x04] = tpso;
			this[0x05] = tsls;
			this[0x06] = airp;

		}
		public FlightPiece (AirportPiece frm, AirportPiece to, FlightTemplatePiece tmplt, TimePiece tpsa, TimePiece tpso, TimePiece tsls, AirplanePiece airp) : this(null,frm,to,tmplt,tpsa,tpso,tsls,airp) {

		}

	}
}

