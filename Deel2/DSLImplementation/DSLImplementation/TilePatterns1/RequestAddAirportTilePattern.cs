using System;

namespace DSLImplementation.UserInterface {
		
	public class RequestAddAirportTilePattern : TilePatternBase {

		public RequestAddAirportTilePattern () : base(null) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilePatternBase
		protected override DSLImplementation.XmlRepresentation.IXmlRequest InternalToTransferCode (IPuzzlePiece root, System.Collections.Generic.Dictionary<string, object> bindings)
		{
			throw new System.NotImplementedException ();
		}
		#endregion


	}

}