using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cairo;
using Gtk;

namespace DSLImplementation {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		private INode injectionNode;
		private IEdge injectionEdge;
		private INode hoverNode = null;
		private INode edgeOffset = null;
		private PointD mouseOffset = new PointD();
		private bool drawEdge = false;
		private readonly List<IPaintPrimitive> primitives = new List<IPaintPrimitive>();

		public INode InjectionNode {
			get {
				return this.injectionNode;
			}
			set {
				this.injectionNode = value;
			}
		}
		public IEdge InjectionEdge {
			get {
				return this.injectionEdge;
			}
			set {
				this.injectionEdge = value;
			}
		}

		public SketchPad () {
			this.AddEvents((int) (Gdk.EventMask.PointerMotionMask|Gdk.EventMask.ButtonPressMask|Gdk.EventMask.ButtonReleaseMask));
			this.primitives.Add(new RunNode(new PointD(35.0d,35.0d),new PointD(64.0d,64.0d)));
		}

		protected override bool OnMotionNotifyEvent (Gdk.EventMotion evnt) {
			PointD p = new PointD(evnt.X,evnt.Y);
			this.mouseOffset = p;
			if(this.hoverNode != null && this.hoverNode.Contains(p)) {
				this.QueueDraw();
				return base.OnMotionNotifyEvent(evnt);
			}
			foreach(IPaintPrimitive ipp in this.primitives) {
				if(ipp is INode && ipp.Contains(p)) {
					this.hoverNode = (INode) ipp;
					this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Cross);
					QueueDraw();
					return base.OnMotionNotifyEvent(evnt);
				}
			}
			this.hoverNode = null;
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
			if(this.injectionNode != null && this.injectionNode is IPaintPrimitive) {
				this.InjectionNode.Location = new PointD(evnt.X,evnt.Y);
			}
			this.QueueDraw();
			return base.OnMotionNotifyEvent(evnt);
		}

		protected override bool OnButtonPressEvent (Gdk.EventButton ev) {
			if(this.hoverNode != null && this.injectionEdge != null) {
				this.drawEdge = true;
				this.edgeOffset = this.hoverNode;
				this.QueueDraw();
			}
			if(this.injectionNode != null && this.hoverNode == null) {
				this.primitives.Add(this.injectionNode.Clone());
				this.QueueDraw();
			}
			return base.OnButtonPressEvent(ev);
		}
		protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt) {
			if(this.drawEdge) {
				this.drawEdge = false;
				if(this.hoverNode != null && this.hoverNode != this.edgeOffset) {
					string error = string.Empty;
					IEdge e = (IEdge) this.injectionEdge.Clone();
					e.setEdgeNode(0x00,this.edgeOffset);
					e.setEdgeNode(0x01,this.hoverNode);
					if(!this.hoverNode.AcceptEdge(e,new INode[] {this.edgeOffset,this.hoverNode},ref error)) {
						MessageDialog md = new MessageDialog(null,DialogFlags.DestroyWithParent,MessageType.Error,ButtonsType.Ok,error);
						md.Title = "Error while adding a conceptual binding!";
						md.Run();
						md.HideAll();
						md.Dispose();
					}
					else {
						this.primitives.Add(e);
					}
				}
			}
			this.edgeOffset = null;
			return base.OnButtonReleaseEvent (evnt);
		}
		internal void AddPrimitive (IPaintPrimitive ipp)
		{
			this.primitives.Add(ipp);
			this.QueueDraw();
		}

		protected override void PaintWidget (Cairo.Context ctx, int w, int h) {
			foreach(IPaintPrimitive ipp in this.primitives) {
				ipp.Paint(ctx);
			}
			base.PaintWidget(ctx, w, h);
			ctx.LineWidth = 0.5d;
			ctx.Color = new Color(0.25d,0.25d,0.25d);
			if(this.drawEdge) {
				ctx.MoveTo(this.edgeOffset.Location);
				ctx.LineTo(this.mouseOffset);
				ctx.Stroke();
			}
			else if(this.InjectionNode != null && this.hoverNode == null) {
				injectionNode.PaintContour(ctx);
			}
		}

	}

}