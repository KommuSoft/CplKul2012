using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	[TilingPattern]
	public class AddCountryTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> typetree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(CountryPiece),0x00,"name","countryname"));

		public AddCountryTilePattern () : base(typetree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string,object> bindings) {
			return new RequestAddCountry(new Country((string) bindings["countryname"]));
		}

	}
}

