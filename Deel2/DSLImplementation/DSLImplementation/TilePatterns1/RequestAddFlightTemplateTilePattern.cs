using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilePattern]
	public class RequestAddFlightTemplateTilePattern : TilePatternBase {

		private static Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(FlightTemplatePiece),0x00,"code","flightcode"));

		public RequestAddFlightTemplateTilePattern () : base(bindtree) {}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddFlightTemplate(new FlightTemplate((string) bindings["flightcode"]));
		}

	}

}