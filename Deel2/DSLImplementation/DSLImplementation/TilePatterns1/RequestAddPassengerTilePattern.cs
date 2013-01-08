using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilePattern]
	public class RequestAddPassengerTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(PassengerPiece),0x00,"name","personname"));

		public RequestAddPassengerTilePattern () : base(bindtree)
		{
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddPassenger(new Passenger((string) bindings["personname"]));
		}

	}

}