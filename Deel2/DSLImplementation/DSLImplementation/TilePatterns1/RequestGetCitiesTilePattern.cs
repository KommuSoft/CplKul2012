using System;
using DSLImplementation.XmlRepresentation;
using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	[TilePatternAttribute]
	public class RequestGetCitiesTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new TypeBind(typeof(CityPiece),0x00),new TypeBind(typeof(CountryPiece),"name","countryname"));

		public RequestGetCitiesTilePattern () : base(bindtree) {}

		#region implemented abstract members of DSLImplementation.UserInterface.TilingPatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestGetCities(new Country((string) bindings["countryname"]));
		}
		#endregion

	}

}

