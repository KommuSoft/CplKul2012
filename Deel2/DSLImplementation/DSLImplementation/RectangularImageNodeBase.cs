using System;
using Cairo;

namespace DSLImplementation {

	public abstract class RectangularImageNodeBase : RectangularNodeBase {

		private string imageName;
		private Pattern pattern;
		private ImageSurface imsu;

		protected abstract string DefaultImageName {
			get;
		}
		protected string ImageName {
			get {
				return this.imageName;
			}
			set {
				this.imageName = value;
				if(this.imageName != string.Empty && this.imageName != null) {
					this.imsu = ImageLoader.LoadSurface(this.imageName);
				}
				else {
					this.imsu = null;
				}
				this.reloadPattern(this,EventArgs.Empty);
			}
		}

		public RectangularImageNodeBase () : base() {
			this.ImageName = this.DefaultImageName;
			this.BoundsChanged += reloadPattern;
		}
		public RectangularImageNodeBase (PointD location) : base(location) {
			this.ImageName = this.DefaultImageName;
			this.BoundsChanged += reloadPattern;
		}
		public RectangularImageNodeBase (PointD center, PointD size) : base(center,size) {
			this.ImageName = this.DefaultImageName;
			this.BoundsChanged += reloadPattern;
		}

		private void reloadPattern (object s, EventArgs e)
		{
			if (this.imsu == null) {
				this.pattern = null;
			} else {
				double ws = imsu.Width/this.Size.X;
				double hs = imsu.Height/this.Size.Y;
				Matrix m = new Matrix(ws,0.0d,0.0d,hs,(-this.Location.X+0.5d*this.Size.X)*ws,(-this.Location.Y+0.5d*this.Size.Y)*hs);
				this.pattern = new SurfacePattern(this.imsu);
				this.pattern.Matrix = m;
			}
		}

		public override void Paint (Context ctx) {
			if(this.pattern != null) {
				ctx.Rectangle(this.GetBounds());
				ctx.Source = this.pattern;
				ctx.Fill();
			}
		}

	}
}

