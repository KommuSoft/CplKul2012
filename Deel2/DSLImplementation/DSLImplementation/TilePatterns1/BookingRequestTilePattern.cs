using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	//[TilingPattern]
	public class BookingRequestTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> typebind = new Tree<TypeBind>(typeof(BookingPiece),typeof(PassengerPiece));

		public BookingRequestTilePattern () : base(typebind) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilingPatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return null;
		}
		#endregion

	}
}

