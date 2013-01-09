using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilePattern]
	public class RequestAddAirlineTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirlinePiece),0x00,"name","airlinename","code","airlinecode"));

		public RequestAddAirlineTilePattern () : base(bindtree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddAirline(new Airline((string) bindings["airlinename"],(string) bindings["airlinecode"]));
		}

	}

}