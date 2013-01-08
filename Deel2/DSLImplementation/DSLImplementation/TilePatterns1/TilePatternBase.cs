using System;
using System.Collections.Generic;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	public abstract class TilePatternBase : ITilePattern {

		Tree<TypeBind> pattern;

		protected TilePatternBase (Tree<TypeBind> pattern) {
			this.pattern = pattern;
		}

		#region ITilingPattern implementation
		public bool Match (IPuzzlePiece root) {
			ITree<IPuzzlePiece> tmp;
			return Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(this.pattern,0x00,root,TypeBind.Match,out tmp);
		}

		public IXmlRequest ToTransferCode (IPuzzlePiece root) {
			ITree<IPuzzlePiece> tmp;
			Tree<TypeBind>.ConjunctiveTreeSwapMatchPredicate(this.pattern,0x00,root,TypeBind.Match,out tmp);
			Dictionary<string,object> bindings = new Dictionary<string, object>();
			Tree<TypeBind>.ConjunctiveTreeNonSwapMatchPredicate(this.pattern,0x00,root,(x,y,z) => TypeBind.MatchAndBind(x,y,z,bindings));
			return InternalToTransferCode(root, bindings);
		}
		#endregion
		protected abstract IXmlRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings);

	}

}