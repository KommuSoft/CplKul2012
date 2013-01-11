using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddAirlineTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirlinePiece),0x00,"name","airlinename","code","airlinecode"));

		public RequestAddAirlineTilePattern () : base(bindtree) {
		}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddAirline(new Airline((string) bindings["airlinename"],(string) bindings["airlinecode"]));
		}

	}

}