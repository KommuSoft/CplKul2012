using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public class RequestGetFlightsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new TypeBind(typeof(FlightPiece),0x00),typeof(ILocationPiece),typeof(ILocationPiece));

		public RequestGetFlightsTilePattern () : base(bindtree) {}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestGetFlights();
		}

	}
}

