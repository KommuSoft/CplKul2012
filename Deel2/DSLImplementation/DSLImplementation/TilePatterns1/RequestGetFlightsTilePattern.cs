using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public class RequestGetFlightsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new Tree<TypeBind>(new TypeBind(typeof(FlightPiece),0x00),typeof(ILocationPiece),typeof(ILocationPiece),new TypeBind(typeof(TimePiece),"time","time"),new TypeBind(typeof(AirlinePiece),"code","airlinecode"),new TypeBind(typeof(SeatClass),"name","classname")));

		public RequestGetFlightsTilePattern () : base(bindtree) {}

		protected override IRequest InternalToTransferCodeBase (IPuzzlePiece root, ITree<IPuzzlePiece> matchtree, Dictionary<string, object> bindings)
		{
			ILocation loca = TilingUtils.MatchLocation (root [0x01]);
			ILocation locb = TilingUtils.MatchLocation (root [0x02]);
			DateTime dt = (DateTime)bindings ["time"];
			Airline al = new Airline ((string)bindings ["airlinecode"]);
			SeatClass sc = new SeatClass ((string)bindings ["classname"]);
			if (loca is Country && locb is Country) {
				return new RequestGetFlights ((Country)loca, (Country)locb, dt, al, sc);
			} else if (loca is City && locb is City) {
				return new RequestGetFlights ((City)loca, (City)locb, dt, al, sc);
			} else if (loca is Airport && locb is Airport) {
				return new RequestGetFlights ((Airport)loca, (Airport)locb, dt, al, sc);
			} else {
				return null;
			}
		}

	}
}

