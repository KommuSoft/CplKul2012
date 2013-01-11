using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestGetFlightsTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(QueryPiece),new Tree<TypeBind>(new TypeBind(typeof(FlightPiece),0x00),typeof(ILocationPiece),typeof(ILocationPiece),new TypeBind(typeof(TimePiece),true,"time","time"),new TypeBind(typeof(AirlinePiece),true,"code","airlinecode"),new TypeBind(typeof(SeatClass),true,"name","classname")));

		public RequestGetFlightsTilePattern () : base(bindtree) {}

		protected override IRequest InternalToTransferCodeBase (IPuzzlePiece root, ITree<IPuzzlePiece> matchtree, Dictionary<string, object> bindings)
		{
			ILocation loca = TilingUtils.MatchLocation (matchtree.ChildAt(0x00).ChildAt(0x00).Data);
			ILocation locb = TilingUtils.MatchLocation (matchtree.ChildAt(0x00).ChildAt(0x01).Data);
			DateTime dt = bindings.ValueOrDefault<string,object,DateTime>("time");
			string als = bindings.ValueOrDefault<string,object,string>("airlinecode");
			string scs = bindings.ValueOrDefault<string,object,string>("classname");
			Airline al = null;
			SeatClass sc = null;
			if(als != null) {
				al = new Airline (als);
			}
			if(scs != null) {
				sc = new SeatClass (scs);
			}
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

