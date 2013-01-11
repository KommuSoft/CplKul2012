using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public abstract class TilePatternBase : ITilePattern {

		Tree<TypeBind> pattern;

		protected TilePatternBase (Tree<TypeBind> pattern) {
			this.pattern = pattern;
		}

		#region ITilingPattern implementation
		public bool Match (IPuzzlePiece root) {
			ITree<IPuzzlePiece> tmp;
			bool res = Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(this.pattern,0x00,root,TypeBind.Match,TypeBind.GetOptional,out tmp);
			return res;
		}

		public IRequest ToTransferCode (IPuzzlePiece root) {
			return TilingUtils.MatchBindExecute (this.pattern, root, this.InternalToTransferCodeBase);
		}
		#endregion
		protected virtual IRequest InternalToTransferCodeBase (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings) {
			return InternalToTransferCode(root,bindings);
		}
		protected virtual IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return InternalToTransferCode(root);
		}
		protected virtual IRequest InternalToTransferCode (IPuzzlePiece root) {
			return null;
		}

	}

}