using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cairo;
using Gtk;

namespace DSLImplementation.UserInterface {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		private IPuzzlePiece rootpiece;
		private Context subcontext;

		public IPuzzlePiece RootPiece {
			get {
				return this.rootpiece;
			}
			set {
				this.rootpiece = value;
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
				IPuzzlePiece ipp = this.rootpiece.GetPuzzleGap(this.subcontext,new PointD(evnt.X,evnt.Y),out index);
				if(ipp != null) {

				}
			}
			return base.OnMotionNotifyEvent (evnt);
		}

		protected override void PaintWidget (Cairo.Context ctx, int w, int h) {
			base.PaintWidget(ctx, w, h);
			if(this.rootpiece != null) {
				ctx.Translate(5.0d,5.0d);
				this.rootpiece.Paint(ctx);
			}
		}

	}

}