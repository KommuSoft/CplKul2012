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
			Console.WriteLine("CHECKING PATTERN {0}",this);
			ITree<IPuzzlePiece> tmp;
			return Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(this.pattern,0x00,root,TypeBind.Match,out tmp);
		}

		public IXmlRequest ToTransferCode (IPuzzlePiece root) {
			return TilingUtils.MatchBindExecute(this.pattern,root,this.InternalToTransferCodeBase);
		}
		#endregion
		protected virtual IXmlRequest InternalToTransferCodeBase (IPuzzlePiece root, ITree<IPuzzlePiece> sortedtree, Dictionary<string, object> bindings) {
			return InternalToTransferCode(root,bindings);
		}
		protected virtual IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return InternalToTransferCode(root);
		}
		protected virtual IXmlRequest InternalToTransferCode (IPuzzlePiece root) {
			return null;
		}

	}

}