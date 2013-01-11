using System.Collections.Generic;
using DSLImplementation.IntermediateCode;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddAirplaneTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirplanePiece),0x00,"type","airplanetype","code","airplanecode"));
		private static readonly TypeBind bindseat = new TypeBind(typeof(SeatPiece),"number","number");
		private static readonly TypeBind bindclass = new TypeBind(typeof(ClassPiece),"name","name");

		public RequestAddAirplaneTilePattern () : base(bindtree) {
		}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			List<Seat> seats = new List<Seat>();
			int n = root.NumberOfChildren;
			Dictionary<string,object> bind = new Dictionary<string,object>();
			for(int i = 0x01; i < n; i++) {
				if(bindseat.MatchBind(i,root[i],bind)) {
					if(bind["number"] != null) {
						int m = (int) bind["number"];
						IPuzzlePiece seatclass = root[i][0x00];
						if(bindclass.MatchBind(i,seatclass,bind)) {
							SeatClass sc = new SeatClass((string) bind["name"]);
							seats.Add(new Seat(sc,m));
						}
					}
					bind.Clear();
				}
			}
			return new RequestAddAirplane(new Airplane((string) bindings["airplanetype"],seats,(string) bindings["airplanecode"]));
		}

	}
}

