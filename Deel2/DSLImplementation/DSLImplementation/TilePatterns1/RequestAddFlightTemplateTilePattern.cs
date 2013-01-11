using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddFlightTemplateTilePattern : TilePatternBase {

		private static Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(FlightTemplatePiece),0x00,"code","flightcode"));

		public RequestAddFlightTemplateTilePattern () : base(bindtree) {}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddFlightTemplate(new FlightTemplate((string) bindings["flightcode"]));
		}

	}

}