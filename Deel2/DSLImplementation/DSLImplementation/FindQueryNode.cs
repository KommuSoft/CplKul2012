using System;
using Cairo;

namespace DSLImplementation {

	[Node("Find","find.png","A node that represents a certain object that must be found in the database. A find node is always the root of a query. Connected items are hints what to find and what the characteristics are.")]
	public class FindQueryNode : RectangularImageTextNodeBase {

		protected override string DefaultImageName {
			get {
				return "find.png";
			}
		}
		protected override string DefaultText {
			get {
				return "FindQuery";
			}
		}

		public FindQueryNode () {}
		public FindQueryNode (PointD location) : base(location) {}
		public FindQueryNode (PointD location, PointD size) : base(location,size) {}

		public override bool AcceptEdge (IEdge edge, System.Collections.Generic.ICollection<INode> othernodes, ref string message) {
			return true;
		}

		public override IPaintPrimitive Clone ()
		{
			return new FindQueryNode(this.Location,this.Size);
		}

	}

}