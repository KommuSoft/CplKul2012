using System;
using System.Collections.Generic;
using System.Reflection;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	public class TilingAlgorithm : IPuzzleQueryResolver {

		private static readonly List<ITilingPattern> patterns = new List<ITilingPattern>();

		public TilingAlgorithm () {
		}

		public static void LoadAssembly (Assembly asm)
		{
			Type[] empty = new Type[0x00];
			object[] emptyargs = new object[0x00];
			foreach(Type t in asm.GetTypes()) {
				if(!t.IsAbstract && t.IsClass && typeof(ITilingPattern).IsAssignableFrom(t) && t.GetCustomAttributes(typeof(TilingPatternAttribute),false).Length > 0x00) {
					ConstructorInfo ci = t.GetConstructor(empty);
					if(ci != null) {
						patterns.Add((ITilingPattern) ci.Invoke(emptyargs));
					}
				}
			}
		}

		public IXmlRequest Tile (RunPiece root) {
			return Tile(root[0x00]);
		}
		public IXmlRequest Tile (IPuzzlePiece ipp) {
			foreach(ITilingPattern tp in patterns) {
				//Console.WriteLine("CHECKING {0}",tp);
				if(tp.Match(ipp)) {
					return tp.ToTransferCode(ipp);
				}
			}
			return null;
		}

		public IPuzzlePiece[] Resolve (IPuzzlePiece query) {
			IXmlRequest ixq = Tile((RunPiece) query);
			IXmlAnswer ixr = ixq.execute();
			return new IPuzzlePiece[] {new TimePiece(),new AirportPiece(),new FlightPiece(),new PassengerPiece(),new PassengerPiece()};
		}

	}
}

