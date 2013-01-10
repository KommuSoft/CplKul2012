using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public class RequestGetFlightsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new TypeBind(typeof(FlightPiece),0x00),typeof(ILocationPiece),typeof(ILocationPiece));
		private static readonly Tree<TypeBind> bindcoun = new Tree<TypeBind>(new TypeBind(CountryPiece,"name","countryname"));
		private static readonly Tree<TypeBind> bindcity = new Tree<TypeBind>(new TypeBind(typeof(CityPiece),"name","cityname"),bindcoun);
		//private static readonly Tree<TypeBind> bindcity = new Tree<TypeBind>();

		public RequestGetFlightsTilePattern () : base(bindtree) {}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, ITree<IPuzzlePiece> matchtree, Dictionary<string, object> bindings) {
			//return new RequestGetFlights();
			return null;
		}

		private ILocationPiece MatchLocation (ILocationPiece locationpiece) {
			return null;
		}

	}
}

