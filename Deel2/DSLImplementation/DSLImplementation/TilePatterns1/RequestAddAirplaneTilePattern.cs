using System.Collections.Generic;
using DSLImplementation.IntermediateCode;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddAirplaneTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirplanePiece),0x00,"type","airplanetype"));

		public RequestAddAirplaneTilePattern () : base(bindtree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddAirplane(new Airplane((string) bindings["airplanetype"]));//TODO: add seats
		}

	}
}

