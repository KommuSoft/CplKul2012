using System;
using Cairo;

namespace DSLImplementation {

	[Edge("Arrow","arrow.png","A connection to bind two concepts with each other. By this connection, semantical bindings are made.")]
	public class Arrow : Edge2Base {

		public Arrow () {}
		public Arrow (INode node1, INode node2) : base(node1,node2) {}
		#region implemented abstract members of DSLImplementation.Edge2Base
		public override void Paint (Context ctx) {
			double dx = this.Location2.X-this.Location1.X;
			double dy = this.Location2.Y-this.Location1.Y;
			double rinv = 15.0d/Math.Sqrt(dx*dx+dy*dy);
			ctx.MoveTo(this.Location1);
			ctx.LineTo(this.Location2);
			double xa = -dx*rinv, ya = -dy*rinv;
			ExtensionMethods.Rotate(ref xa,ref ya,0.261799333d);
			ctx.MoveTo(xa+this.Location2.X,ya+this.Location2.Y);
			ctx.LineTo(this.Location2);
			xa = -dx*rinv;
			ya = -dy*rinv;
			ExtensionMethods.Rotate(ref xa,ref ya,-0.261799333d);
			ctx.LineTo(xa+this.Location2.X,ya+this.Location2.Y);
			ctx.Stroke();
		}

		public override IPaintPrimitive Clone () {
			return new Arrow();
		}

		public override bool Contains (PointD point)
		{
			if (!this.Location1.Equals(this.Location2)) {
				double dx = this.Location2.X - this.Location1.X;
				double dy = this.Location2.Y - this.Location1.Y;
				double rinv = 1.0d / Math.Sqrt (dx * dx + dy * dy);
				double distance = point.X * rinv * dy - point.Y * rinv * dx;
				return Math.Abs (distance) <= 2.0d;
			} else {
				return false;
			}
		}
		#endregion

	}
}

