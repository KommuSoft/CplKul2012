using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddFlightTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new Tree<TypeBind>(new TypeBind(typeof(FlightPiece),0x00,"distance","distance"),
		                                                                     new TypeBind(typeof(AirportPiece),"code","startcode"),
		                                                                     new TypeBind(typeof(AirportPiece),"code","stopcode"),
		                                                                     new TypeBind(typeof(FlightTemplatePiece),"code","flighttemplatecode"),
		                                                                     new TypeBind(typeof(TimePiece),"time","starttime"),
		                                                                     new TypeBind(typeof(TimePiece),"time","stoptime"),
		                                                                     new TypeBind(typeof(AirplanePiece),"code","airplanecode")));

		public RequestAddFlightTilePattern () : base(bindtree) {
		}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			string ftc = (string) bindings["flighttemplatecode"];
			string sac = (string) bindings["startcode"];
			string soc = (string) bindings["stopcode"];
			string apc = (string) bindings["airplanecode"];
			int distance = (int) bindings["distance"];
			DateTime sat = (DateTime) bindings["starttime"];
			DateTime sot = (DateTime) bindings["stoptime"];
			return new RequestAddFlight(new Flight(new FlightTemplate(ftc),sat,sot,new Airport(sac),new Airport(soc),new Airplane(apc),distance));
		}

	}

}