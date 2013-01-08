using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {
		
	public class RequestAddAirportTilePattern : TilePatternBase {

		//private Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),);

		public RequestAddAirportTilePattern () : base(null) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilePatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			throw new System.NotImplementedException ();
		}
		#endregion


	}

}