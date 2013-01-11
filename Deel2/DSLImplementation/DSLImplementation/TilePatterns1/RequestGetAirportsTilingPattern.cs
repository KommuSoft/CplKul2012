using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;
using System.Collections.Generic;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestGetAirportsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new TypeBind(typeof(AirportPiece),0x00),new TypeBind(typeof(CityPiece),"name","citynamename"),new TypeBind(typeof(CountryPiece),"name","countryname"));

		public RequestGetAirportsTilePattern () : base(bindtree) {}

		#region implemented abstract members of DSLImplementation.UserInterface.TilingPatternBase
		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			Country country = new Country((string) bindings["countryname"]);
			return new RequestGetAirports(new City((string) bindings["cityname"],country));
		}
		#endregion

	}

}