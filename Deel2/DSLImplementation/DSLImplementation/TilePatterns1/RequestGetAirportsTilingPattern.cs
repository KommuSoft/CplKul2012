using System;
using DSLImplementation.XmlRepresentation;
using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	[TilingPattern]
	public class RequestGetAirportsTilePattern : TilingPatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),typeof(AirportPiece),new TypeBind(typeof(CityPiece),"name","citynamename"),new TypeBind(typeof(CountryPiece),"name","countryname"));

		public RequestGetAirportsTilePattern () : base(bindtree) {}

		#region implemented abstract members of DSLImplementation.UserInterface.TilingPatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			Country country = new Country((string) bindings["countryname"]);
			return new RequestGetAirports(new City((string) bindings["cityname"],country),country);
		}
		#endregion

	}

}