using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public class RequestGetFlightsTilingPattern : TilePatternBase {

		//private static readonly 
		//TODO: implement!!!

		public RequestGetFlightsTilingPattern () : base(null) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return null;
		}

	}

}