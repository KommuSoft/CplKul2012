using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Cairo;
using Gtk;

namespace DSLImplementation.UserInterface {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		public const double Margin = 0x08;
		private RunPiece rootpiece;
		private IPuzzlePiece linkpiece = null;
		private Context subcontext;
		private ConstructorInfo injectionPiece;
		private SketchPadTool tool;
		private readonly Stack<QueryAnswerLocations> qas = new Stack<QueryAnswerLocations>();
		private static readonly object[] emptyArgs = new object[0x00];
		private bool autorun = true;
		private readonly IPuzzleQueryResolver resolver;

		public bool Autorun {
			get {
				return this.autorun;
			}
			set {
				this.autorun = value;
			}
		}

		public RunPiece RootPiece {
			get {
				return this.rootpiece;
			}
			set {
				if(this.rootpiece != value) {
					if(this.rootpiece != null) {
						this.rootpiece.BoundsChanged -= handleBoundsChanged;
					}
					this.rootpiece = value;
					if(this.rootpiece != null) {
						this.rootpiece.BoundsChanged += handleBoundsChanged;
					}
					this.handleBoundsChanged(this,EventArgs.Empty);
				}
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
		public SketchPadTool Tool {
			get {
				return this.tool;
			}
			set {
				this.tool = value;
			}
		}

		public SketchPad (IPuzzleQueryResolver resolver) {
			ImageSurface imsu = new ImageSurface(Format.Argb32,0x01,0x01);
			this.subcontext = new Context(imsu);
			this.AddEvents((int) (Gdk.EventMask.PointerMotionMask|Gdk.EventMask.ButtonPressMask|Gdk.EventMask.ButtonReleaseMask));
			this.resolver = resolver;
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
			switch (this.Tool) {
			case SketchPadTool.CreateNew:
				if (this.injectionPiece != null && this.rootpiece != null) {
					int index;
					IPuzzlePiece ipp = this.rootpiece.GetPuzzleGap (this.subcontext, new PointD (evnt.X - 5.0d, evnt.Y - 5.0d), out index);
					if (ipp != null) {
						try {
							ipp [index] = (IPuzzlePiece)this.injectionPiece.Invoke (emptyArgs);
							this.QueueDraw ();
						} catch (Exception e) {
							MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, e.Message);
							md.Run ();
							md.HideAll ();
							md.Dispose ();
						}
					}
				}
				break;
			case SketchPadTool.Link :
				break;
			}
			return base.OnButtonPressEvent (evnt);
		}

		protected override void PaintWidget (Cairo.Context ctx, int w, int h) {
			base.PaintWidget(ctx, w, h);
			ctx.Pattern = KnownColors.ConstructionPattern;
			ctx.Paint();
			ctx.Color = KnownColors.Black;
			double y0 = Margin;
			if(this.rootpiece != null) {
				ctx.Save();
				ctx.Translate(Margin,y0);
				this.rootpiece.Paint(ctx);
				ctx.Restore();
			}
			foreach(QueryAnswerLocations qal in this.qas) {
				qal.Paint(ctx);
			}
		}
		private void AddQueryAnswer (QueryAnswerLocations qa) {
			if(qa != null) {
				this.qas.Push(qa);
				qa.BoundsChanged += handleBoundsChanged;
			}
		}

		private void handleBoundsChanged (object sender, EventArgs e) {
			double y = Margin;
			if(this.rootpiece != null) {
				y += this.rootpiece.MeasureSize(this.subcontext).Y+Margin;
			}
			foreach(QueryAnswerLocations qal in this.qas) {
				qal.Offset = new PointD(Margin,y);
				y += qal.MeasureSize(this.subcontext).Y+Margin;
			}
		}
		public void ExecuteQuery () {
			QueryAnswerLocations qal = new QueryAnswerLocations(this.rootpiece,this.resolver.Resolve(this.rootpiece));
			this.AddQueryAnswer(qal);
			this.RootPiece = new RunPiece();
			this.QueueDraw();
		}

		private class QueryAnswerLocations : IPuzzlePiece {

			private RunPiece query;
			private PointD offset;
			private IPuzzlePiece[] answers;
			private PointD[] locations;
			private PointD size = new PointD(-0x01,-0x01);
			private event EventHandler boundsChanged;
			private int index;
			public const double Margin = 10.0d;

			public IPuzzlePiece PieceParent {
				get {
					return null;
				}
				set {}
			}
			public bool Complete {
				get {
					return true;
				}
			}
			public bool IsLeaf {
				get {
					return false;
				}
			}
			public int Index {
				get {
					return this.index;
				}
				set {
					this.index = value;
				}
			}
			public TypeColors TypeColors {
				get {
					return TypeColors.None;
				}
			}
			public IPuzzlePiece this [int index] {
				get {
					if (index == 0x00) {
						return this.Query;
					} else {
						return this.Answer [index - 0x01];
					}
				}
				set {
					throw new InvalidOperationException("Cannot set the values of a query answer!");
				}
			}
			public event EventHandler BoundsChanged {
				add {
					this.boundsChanged += value;
				}
				remove {
					this.boundsChanged -= value;
				}
			}
			public int NumberOfArguments {
				get {
					return this.Answer.Length+0x01;
				}
			}
			public PointD Offset {
				get {
					return this.offset;
				}
				set {
					this.offset = value;
				}
			}
			public RunPiece Query {
				get {
					return this.query;
				}
			}
			public IPuzzlePiece[] Answer {
				get {
					return this.answers;
				}
			}
			public PointD[] Locations {
				get {
					return this.locations;
				}
			}
			public int NumberOfPieces {
				get {
					return this.Answer.Length+0x01;
				}
			}

			private QueryAnswerLocations (RunPiece query, PointD offset, IPuzzlePiece[] answer, PointD[] locations) {
				this.query = query;
				this.offset = offset;
				this.answers = answer;
				this.locations = locations;
			}
			public QueryAnswerLocations (RunPiece query, params IPuzzlePiece[] answer) : this(query,new PointD(),answer,new PointD[answer.Length+0x01]) {}
			public QueryAnswerLocations (RunPiece query, IEnumerable<IPuzzlePiece> answer) : this(query,new PointD(),answer.ToArray(),new PointD[answer.Count()+0x01]) {}

			public IEnumerable<IPuzzlePiece> GetAllPieces () {
				yield return this.Query;
				foreach(IPuzzlePiece a in this.Answer) {
					yield return a;
				}
			}
			private void registerChildren ()
			{
				foreach(IPuzzlePiece ipp in this.AllPieces()) {
					ipp.BoundsChanged += handleBoundsChanged;
				}
			}
			private void handleBoundsChanged (object s, EventArgs e) {
				this.size.X = -0x01;
				if(this.boundsChanged != null) {
					this.boundsChanged(this,e);
				}
			}
			public void Paint (Context ctx) {
				ctx.Save();
				ctx.Translate(this.offset.X,this.offset.Y);
				foreach(IPuzzlePiece ipp in this.AllPieces()) {
					ipp.Paint(ctx);
					ctx.Translate(Margin+ipp.MeasureSize(ctx).X,0.0d);
				}
				ctx.Restore();
			}
			public IEnumerable<IPuzzlePiece> AllPieces () {
				yield return Query;
				foreach(IPuzzlePiece a in this.Answer) {
					yield return a;
				}
			}
			public PointD InnerLocation (Context ctx)
			{
				return this.Offset;
			}
			public PointD OuterLocation (Context ctx) {
				return this.Offset;
			}
			public PointD MeasureSize (Context ctx) {
				if(this.size.X < 0x00) {
					size.X = 0.0d;
					size.Y = 0.0d;
					PointD siz;
					int index = 0x00;
					foreach(IPuzzlePiece ipp in AllPieces()) {
						siz = ipp.MeasureSize(ctx);
						size.X += siz.X+Margin;
						size.Y = Math.Max(size.Y,siz.Y);
						this.Locations[index++] = new PointD(size.X,0.0d);
					}
					size.X -= Margin;
				}
				return size;
			}
			public PointD ChildLocation (Context ctx, int index) {
				MeasureSize(ctx);
				return this.Locations[index];
			}
			public IPuzzlePiece GetPuzzleGap (Context ctx, PointD p, out int index)
			{
				index = -0x01;
				return null;
			}
			public IPuzzlePiece GetPuzzlePiece (Context ctx, PointD p) {
				return null;
			}
			public bool MatchesConstraints (int index, IPuzzlePiece piece) {
				return false;
			}
			public bool IsOptional (int index) {
				return false;
			}

		}

	}

}