using System;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public static class TilingUtils {

		private static readonly Tree<TypeBind> bindcoun = new Tree<TypeBind>(new TypeBind(typeof(CountryPiece),"name","countryname"));
		private static readonly Tree<TypeBind> bindcity = new Tree<TypeBind>(new TypeBind(typeof(CityPiece),"name","cityname"),bindcoun);
		private static readonly Tree<TypeBind> bindairp = new Tree<TypeBind>(new TypeBind(typeof(AirportPiece),"code","airportcode"));

		public static ILocationPiece MatchLocation (ILocationPiece root) {
			ITree<IPuzzlePiece> tmp;
			Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(this.pattern,0x00,root,TypeBind.Match,out tmp);
			Dictionary<string,object> bindings = new Dictionary<string, object>();
			Tree<TypeBind>.ConjunctiveTreeNonSwapMatchPredicate(this.pattern,0x00,root,(x,y,z) => TypeBind.MatchBind(x,y,z,bindings));
			return InternalToTransferCode(root, bindings);
		}

	}

}