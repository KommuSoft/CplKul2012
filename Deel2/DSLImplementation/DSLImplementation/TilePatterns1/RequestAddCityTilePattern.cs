using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePatternAttribute]
	public class RequestAddCityTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new Tree<TypeBind>(new TypeBind(typeof(CityPiece),0x00,"name","cityname"),new TypeBind(typeof(CountryPiece),"name","countryname")));

		public RequestAddCityTilePattern () : base(bindtree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddCity(new City((string) bindings["cityname"],new Country((string) bindings["countryname"])));
		}

	}

}