using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public delegate T ParsedBindedTreeExecuter<T> (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings);

	public static class TilingUtils {

		public static readonly Tree<TypeBind> bindcoun = new Tree<TypeBind>(new TypeBind(typeof(CountryPiece),"name","countryname"));
		public static readonly Tree<TypeBind> bindcity = new Tree<TypeBind>(new TypeBind(typeof(CityPiece),"name","cityname"),bindcoun);
		public static readonly Tree<TypeBind> bindairp = new Tree<TypeBind>(new TypeBind(typeof(AirportPiece),"code","airportcode"));

		public static ILocation MatchLocation (IPuzzlePiece root) {
			ILocation iloc = MatchBindExecute(bindairp,root,MatchAirport);
			if(iloc == null) {
				iloc = MatchBindExecute(bindcity,root,MatchCity);
				if(iloc == null) {
					iloc = MatchBindExecute(bindcoun,root,MatchCountry);
				}
			}
			return iloc;
		}
		public static City MatchCity (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings) {
			return new City((string) bindings["cityname"],new Country((string) bindings["countryname"]));
		}
		public static Country MatchCountry (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings) {
			return new Country((string) bindings["countryname"]);
		}
		public static Airport MatchAirport (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings) {
			return new Airport((string) bindings["airportcode"]);
		}
		public static T MatchBindExecute<T> (Tree<TypeBind> pattern, IPuzzlePiece root, ParsedBindedTreeExecuter<T> pbte)
		{
			ITree<IPuzzlePiece> tmp;
			if(!Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(pattern,0x00,root,TypeBind.Match,TypeBind.GetOptional,out tmp)) {
				return default(T);
			}
			Dictionary<string,object> bindings = new Dictionary<string, object>();
			Tree<TypeBind>.ConjunctiveTreeNonSwapMatchPredicate(pattern,0x00,tmp,(x,y,z) => TypeBind.MatchBind(x,y,z,bindings),TypeBind.GetOptional);
			return pbte(root, tmp, bindings);
		}

	}

}