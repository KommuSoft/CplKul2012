using System.Collections.Generic;
using DSLImplementation.IntermediateCode;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddAirplaneTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(AddPiece),new TypeBind(typeof(AirplanePiece),0x00,"type","airplanetype","code","airplanecode"),typeof(SeatPiece));
		private static readonly TypeBind bindseat = new TypeBind(typeof(SeatPiece),"number","number");
		private static readonly TypeBind bindclass = new TypeBind(typeof(ClassPiece),"name","name");

		public RequestAddAirplaneTilePattern () : base(bindtree) {
		}

		protected override IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
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
							/*System.Console.WriteLine("{0}: {1}",sc.Name,m);
							for(int j = 0x00; j < m; j++) {
							}*/
						}
					}
					bind.Clear();
				}
			}
			return new RequestAddAirplane(new Airplane((string) bindings["airplanetype"],seats,(string) bindings["airplanecode"]));
		}

	}
}

