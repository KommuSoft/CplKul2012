using System;
using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilingPattern]
	public class BookingRequestTilePattern : TilingPatternBase {

		private static readonly Tree<TypeBind> typebind = new Tree<TypeBind>(typeof(BookingPiece),typeof(PersonPiece));

		public BookingRequestTilePattern () : base(typebind) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilingPatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return null;
		}
		#endregion

	}
}

