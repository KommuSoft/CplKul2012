using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using DSLImplementation.IntermediateCode;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	public class TilingAlgorithm : IPuzzleQueryResolver {

		private static readonly List<ITilePattern> patterns = new List<ITilePattern>();

		public TilingAlgorithm () {
		}

		public static void LoadAssembly (Assembly asm) {
			Type[] empty = new Type[0x00];
			object[] emptyargs = new object[0x00];
			foreach(Type t in asm.GetTypes()) {
				if(!t.IsAbstract && t.IsClass && typeof(ITilePattern).IsAssignableFrom(t) && t.GetCustomAttributes(typeof(TilePatternAttribute),false).Length > 0x00) {
					ConstructorInfo ci = t.GetConstructor(empty);
					if(ci != null) {
						patterns.Add((ITilePattern) ci.Invoke(emptyargs));
					}
				}
			}
		}

		public IRequest Tile (RunPiece root) {
			return Tile(root[0x00]);
		}
		public IRequest Tile (IPuzzlePiece ipp) {
			foreach(ITilePattern tp in patterns) {
				if(tp.Match(ipp)) {
					return tp.ToTransferCode(ipp);
				}
			}
			return null;
		}

		public IPuzzlePiece[] Resolve (IPuzzlePiece query) {
			IRequest ixq = Tile((RunPiece) query);
			if(ixq == null) {
				return new IPuzzlePiece[] {new SucceedFailPiece("No template")};
			}
			try {
				return ixq.execute().ToPuzzlePieces().ToArray();
			}
			catch(Exception e) {
				return new IPuzzlePiece[] {new SucceedFailPiece(e)};
			}
		}

	}
}

