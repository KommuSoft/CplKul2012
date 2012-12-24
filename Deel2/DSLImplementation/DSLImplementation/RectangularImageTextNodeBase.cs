using System;
using Cairo;

namespace DSLImplementation {

	public abstract class RectangularImageTextNodeBase : RectangularImageNodeBase {

		private string text;
		private event EventHandler textChanged;
		public const double Margin = 5.0d;

		public event EventHandler TextChanged {
			add {
				this.textChanged += value;
			}
			remove {
				this.textChanged -= value;
			}
		}
		public string Text {
			get {
				return this.text;
			}
			set {
				if(this.text != value) {
					this.text = value;
					OnTextChanged(EventArgs.Empty);
				}
			}
		}
		protected abstract string DefaultText {
			get;
		}

		protected RectangularImageTextNodeBase (PointD location, PointD size, string text) : base(location,size) {
			this.Text = text;
		}
		protected RectangularImageTextNodeBase (PointD location, PointD size) : base(location,size) {
			this.Text = DefaultText;
		}
		protected RectangularImageTextNodeBase (PointD location, string text) : base(location) {
			this.Text = text;
		}
		protected RectangularImageTextNodeBase (PointD location) : base(location) {
			this.Text = DefaultText;
		}
		protected RectangularImageTextNodeBase (string Text) {
			this.Text = text;
		}
		protected RectangularImageTextNodeBase () {
			this.Text = DefaultText;
		}

		public override void Paint (Context ctx) {
			base.Paint(ctx);
			TextExtents te = ctx.TextExtents(this.Text);
			ctx.MoveTo(this.Location.X-0.5d*te.Width,this.Location.Y+0.5d*this.Size.Y+Margin);
			ctx.Color = new Color(0.0d,0.0d,0.0d);
			ctx.ShowText(this.Text);
		}
		protected virtual void OnTextChanged (EventArgs e) {
			if(textChanged != null) {
				textChanged(this,e);
			}
		}

	}
}

