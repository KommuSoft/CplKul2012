using System;
using Cairo;

namespace DSLImplementation
{
	public abstract class RectangularNodeBase : NodeBase
	{

		private PointD size = new PointD();

		public PointD Size {
			get {
				return this.size;
			}
			set {
				if(!this.size.Equals(value)) {
					this.size = value;
					this.OnBoundsChanged(EventArgs.Empty);
				}
			}
		}

		public RectangularNodeBase () : this(new PointD()) {
		}
		public RectangularNodeBase (PointD center) : this(center,new PointD(64.0d,64.0d)) {
		}
		public RectangularNodeBase (PointD center, PointD size) : base(center) {
			this.Size = size;
		}

		#region implemented abstract members of DSLImplementation.NodeBase
		public override PointD GetLocationByAngle (double theta)
		{
			double w = this.Size.X;
			double h = this.Size.Y;
			double xc = this.Location.X;
			double yc = this.Location.Y;
			double alpha = Math.Atan2 (h, w);
			if (Math.Abs (theta) <= alpha) {
				return new PointD (xc + 0.5d * w, yc + 0.5d * w * Math.Tan (theta));
			} else if (Math.Abs (theta) >= Math.PI - alpha) {
				return new PointD (xc - 0.5d * w, yc - 0.5d * w * Math.Tan (theta));
			} else if (theta >= 0.0d) {
				return new PointD(xc+0.5d*h*Math.Tan(0.5d*Math.PI-theta),yc+0.5d*h);
			} else {
				return new PointD(xc-0.5d*h*Math.Tan(0.5d*Math.PI-theta),yc-0.5d*h);
			}
		}
		public override void PaintContour (Context ctx) {
			ctx.Rectangle(this.Location.X-0.5d*this.Size.X,this.Location.Y-0.5d*this.Size.Y,this.Size.X,this.size.Y);
			ctx.Stroke();
		}
		public override Rectangle GetBounds () {
			return new Rectangle(this.Location.X-0.5d*this.Size.X,this.Location.Y-0.5d*this.Size.Y,this.Size.X,this.Size.Y);
		}
		public override bool Contains (PointD point) {
			return this.GetBounds().Contains(point);
		}
		#endregion

	}
}

