using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cairo;
using Gtk;

namespace DSLImplementation.UserInterface {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		private IPuzzlePiece rootpiece;

		public IPuzzlePiece RootPiece {
			get {
				return this.rootpiece;
			}
			set {
				this.rootpiece = value;
			}
		}

		public SketchPad () {
			this.AddEvents((int) (Gdk.EventMask.PointerMotionMask|Gdk.EventMask.ButtonPressMask|Gdk.EventMask.ButtonReleaseMask));
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