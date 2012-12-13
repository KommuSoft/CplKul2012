using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cairo;

namespace DSLImplementation {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		private readonly List<PointD> currentLine = new List<PointD>();
		private bool mousePressed = false;

		public SketchPad () {
			this.AddEvents((int)(Gdk.EventMask.PointerMotionMask|Gdk.EventMask.ButtonPressMask|Gdk.EventMask.ButtonReleaseMask));
		}

		protected override bool OnMotionNotifyEvent (Gdk.EventMotion evnt) {
			if(mousePressed) {
				double x = evnt.X, y = evnt.Y;
				currentLine.Add(new PointD(x, y));
				this.QueueDraw();
			}
			return base.OnMotionNotifyEvent(evnt);
		}

		protected override bool OnButtonPressEvent (Gdk.EventButton ev) {
			this.mousePressed = true;
			this.currentLine.Add(new PointD(ev.X, ev.Y));
			this.QueueDraw();
			return base.OnButtonPressEvent(ev);
		}

		protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt) {
			this.mousePressed = false;
			this.currentLine.Clear();
			this.QueueDraw();
			return base.OnButtonReleaseEvent(evnt);
		}

		protected override void PaintWidget (Cairo.Context ctx, int w, int h) {
			base.PaintWidget(ctx, w, h);
			if(currentLine.Count > 0) {
				ctx.MoveTo(currentLine[0]);
				foreach(PointD pt in currentLine) {
					ctx.LineTo(pt);
				}
				ctx.Stroke();
			}
		}
	}

}