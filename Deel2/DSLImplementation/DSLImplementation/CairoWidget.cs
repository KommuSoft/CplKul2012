using System;
using Gtk;
using Gdk;
using Cairo;

namespace DSLImplementation {

	public abstract class CairoWidget : DrawingArea {


		protected virtual void PaintWidget (Context ctx, int w, int h) {
		}

		protected override bool OnExposeEvent (Gdk.EventExpose ev) {
			Context ctx = Gdk.CairoHelper.Create(this.GdkWindow);
			ctx.FillRule = Cairo.FillRule.EvenOdd;
			int w, h;
			this.GdkWindow.GetSize(out w, out h);
			this.PaintWidget(ctx, w, h);
			((IDisposable)ctx.Target).Dispose();
			((IDisposable)ctx).Dispose();
			return base.OnExposeEvent(ev);
		}

	}
}

