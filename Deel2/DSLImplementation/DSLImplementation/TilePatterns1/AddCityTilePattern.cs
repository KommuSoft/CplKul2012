using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilingPattern]
	public class AddCityTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(CityPiece),0x00,"name","cityname"),new TypeBind(typeof(CountryPiece),"name","countryname"));

		public AddCityTilePattern () : base(bindtree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddCity(new City((string) bindings["cityname"],new Country((string) bindings["countryname"])));
		}

	}

}