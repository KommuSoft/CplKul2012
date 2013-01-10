using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public class RequestGetFlightsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new TypeBind(typeof(FlightPiece),0x00),typeof(ILocationPiece),typeof(ILocationPiece));

		public RequestGetFlightsTilePattern () : base(bindtree) {}

		protected override IXmlRequest InternalToTransferCodeBase (IPuzzlePiece root, ITree<IPuzzlePiece> matchtree, Dictionary<string, object> bindings) {
			ILocation loca, locb;
			return null;
		}

	}
}

