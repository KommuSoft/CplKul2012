using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {
		
	public class RequestAddAirportTilePattern : TilePatternBase {

		private Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(Airport),0x00,"name","airportname","code","airportcode")
		                                                     ,new TypeBind(typeof(CityPiece),"name","cityname")
		                                                     ,new TypeBind(typeof(CountryPiece),"name","countryname"));

		public RequestAddAirportTilePattern () : base(null) {

		}

		#region implemented abstract members of DSLImplementation.UserInterface.TilePatternBase
		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddAirport(new Airport((string) bindings["airportname"],
			                                         (string) bindings["airportcode"],
			                                         new City((string) bindings["cityname"],(string) bindings["countryname"])));
		}
		#endregion


	}

}