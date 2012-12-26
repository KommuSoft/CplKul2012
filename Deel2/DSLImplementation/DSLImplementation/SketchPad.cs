using System.Reflection;
using System.ComponentModel;
using Cairo;
using Gtk;

namespace DSLImplementation.UserInterface {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		private IPuzzlePiece rootpiece;
		private Context subcontext;
		private ConstructorInfo injectionPiece;
		private static readonly object[] emptyArgs = new object[0x00];

		public IPuzzlePiece RootPiece {
			get {
				return this.rootpiece;
			}
			set {
				this.rootpiece = value;
			}
		}
		public ConstructorInfo InjectionPiece {
			get {
				return this.injectionPiece;
			}
			set {
				this.injectionPiece = value;
			}
		}

		public SketchPad () {
			ImageSurface imsu = new ImageSurface(Format.Argb32,0x01,0x01);
			this.subcontext = new Context(imsu);
			this.AddEvents((int) (Gdk.EventMask.PointerMotionMask|Gdk.EventMask.ButtonPressMask|Gdk.EventMask.ButtonReleaseMask));
		}

		protected override bool OnMotionNotifyEvent (Gdk.EventMotion evnt) {
			if(this.rootpiece != null) {
				int index;
				IPuzzlePiece ipp = this.rootpiece.GetPuzzleGap(this.subcontext,new PointD(evnt.X-5.0d,evnt.Y-5.0d),out index);
				if(ipp != null) {
					this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.CenterPtr);
				}
				else {
					this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
				}
			}
			return base.OnMotionNotifyEvent (evnt);
		}
		protected override bool OnButtonPressEvent (Gdk.EventButton evnt)
		{
			if (this.injectionPiece != null && this.rootpiece != null) {
				int index;
				IPuzzlePiece ipp = this.rootpiece.GetPuzzleGap (this.subcontext, new PointD (evnt.X - 5.0d, evnt.Y - 5.0d), out index);
				if (ipp != null) {
					ipp[index] = (IPuzzlePiece) this.injectionPiece.Invoke(emptyArgs);
					this.QueueDraw();
				}
			}
			return base.OnButtonPressEvent (evnt);
		}

		protected override void PaintWidget (Cairo.Context ctx, int w, int h) {
			base.PaintWidget(ctx, w, h);
			ctx.Pattern = KnownColors.ConstructionPattern;
			ctx.Paint();
			ctx.Color = KnownColors.Black;
			if(this.rootpiece != null) {
				ctx.Translate(5.0d,5.0d);
				this.rootpiece.Paint(ctx);
			}
		}

	}

}