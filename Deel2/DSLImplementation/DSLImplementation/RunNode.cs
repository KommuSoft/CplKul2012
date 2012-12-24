using System;
using Cairo;

namespace DSLImplementation {

	public class RunNode : RectangularImageTextNodeBase {

		protected override string DefaultText {
			get {
				return "Run";
			}
		}
		protected override string DefaultImageName {
			get {
				return "run.png";
			}
		}

		public RunNode () {}
		public RunNode (PointD location) : base(location) {}
		public RunNode (PointD location, PointD size) : base(location,size) {}

		public override bool AcceptEdge (IEdge edge, System.Collections.Generic.ICollection<INode> othernodes, ref string message) {
			return true;
		}
		public override IPaintPrimitive Clone () {
			return new RunNode(this.Location,this.Size);
		}

	}
}

