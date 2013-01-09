using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {
		
	[TilePattern]
	public class RequestAddAirportTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirportPiece),0x00,"name","airportname","code","airportcode")
		                                                     ,new TypeBind(typeof(CityPiece),"name","cityname")
		                                                     ,new TypeBind(typeof(CountryPiece),"name","countryname"));

		public RequestAddAirportTilePattern () : base(bindtree) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilePatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddAirport(new Airport((string) bindings["airportname"],
			                                         (string) bindings["airportcode"],
			                                         new City((string) bindings["cityname"],new Country((string) bindings["countryname"]))));
		}
		#endregion


	}

}