using System;
using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	public class RequestGetFlightsTilingPattern : TilingPatternBase {

		//private static readonly 

		public RequestGetFlightsTilingPattern () : base(null) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return null;
		}

	}

}