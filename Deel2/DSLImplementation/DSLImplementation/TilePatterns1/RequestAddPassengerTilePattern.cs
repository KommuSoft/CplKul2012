using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddPassengerTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(PassengerPiece),0x00,"name","personname"));

		public RequestAddPassengerTilePattern () : base(bindtree)
		{
		}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddPassenger(new Passenger((string) bindings["personname"]));
		}

	}

}