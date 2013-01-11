using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Cairo;
using DSLImplementation.Tiling;

namespace DSLImplementation.UserInterface {

	[ToolboxItem(true)]
	public class SketchPad : CairoWidget {

		public const double Margin = 0x08;
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
		private RunPiece rootpiece {
			get {
				QueryAnswerLocations aq = this.ActiveQuery;
				if(aq != null) {
					return aq.Query;
				}
				else {
					return null;
				}
			}
			set {
				this.ActiveQuery = new QueryAnswerLocations(value);
			}
		}
		private QueryAnswerLocations ActiveQuery {
			get {
				if(this.qas.Count > 0x00) {
					return this.qas.Peek ();
				}
				else {
					return null;
				}
			}
			set {
				if(this.qas.Count > 0x00) {
					QueryAnswerLocations qat = this.qas.Pop();
					if(qat != null) {
						qat.BoundsChanged -= handleBoundsChanged;
					}
				}
				if(value != null) {
					this.qas.Push(value);
					value.BoundsChanged += handleBoundsChanged;
				}
				this.handleBoundsChanged(this,EventArgs.Empty);
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

		public SketchPad () : this (new TilingAlgorithm())
		{
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
			PointD p = new PointD(evnt.X,evnt.Y);
			IPuzzlePiece ipp;
			switch (this.Tool) {
			case SketchPadTool.CreateNew:
				if (this.injectionPiece != null && this.rootpiece != null) {
					this.AddGap(evnt,(IPuzzlePiece)this.injectionPiece.Invoke (emptyArgs));
				}
				break;
			case SketchPadTool.Link :
				if(this.linkpiece == null) {
					this.linkpiece = this.GetPuzzlePiece(p);
				}
				else {
					this.AddGap(evnt,new LinkPiece(this.linkpiece));
					this.linkpiece = null;
				}
				break;
			case SketchPadTool.Remove :
				ipp = this.GetPuzzlePiece(p);
				if(ipp != null) {
					if(ipp.PieceParent != null) {
						ipp.Kill();
						ipp.PieceParent[ipp.Index] = null;
					}
				}
				break;
			case SketchPadTool.Modify :
				ipp = this.GetPuzzlePiece(p);
				if(ipp != null) {
					if(ipp is IKeyValueTablePuzzlePiece<string,object>) {
						KeyValueTableEditor<string,object>.RunDialog((ipp as IKeyValueTablePuzzlePiece<string,object>).Table);
					}
					else {
						ExtensionMethods.ShowException("Cannot modify: the selected piece doesn't contain any information!");
					}
					ipp.InvalidateSizeCache();
				}
				break;
			}
			this.QueueDraw ();
			return base.OnButtonPressEvent (evnt);
		}

		private void AddGap (Gdk.EventButton evnt, IPuzzlePiece source)
		{
			int index;
			IPuzzlePiece ipp = this.rootpiece.GetPuzzleGap (this.subcontext, new PointD (evnt.X - Margin, evnt.Y - Margin), out index);
			if (ipp != null) {
				try {
					ipp [index] = source;
				} catch (Exception e) {
					ExtensionMethods.ShowException (e);
				}
			}
		}
		private IPuzzlePiece GetPuzzlePiece (PointD p) {
			PointD siz;
			if(this.rootpiece != null) {
				siz = this.rootpiece.MeasureSize(this.subcontext);
				if(p.X >= Margin && p.Y >= Margin && p.X < siz.X-Margin && p.Y < siz.Y-Margin) {
					p.X -= Margin;
					p.Y -= Margin;
					return this.rootpiece.GetPuzzlePiece(this.subcontext,p);
				}
			}
			foreach(QueryAnswerLocations qal in this.qas) {
				double dx = p.X-qal.Offset.X;
				double dy = p.Y-qal.Offset.Y;
				siz = qal.MeasureSize(this.subcontext);
				if(dx >= 0.0d && dy >= 0.0d && dx < siz.X && dy < siz.Y) {
					p.X = dx;
					p.Y = dy;
					return qal.GetPuzzlePiece(this.subcontext,p);
				}
			}
			return null;
		}

		public void PaintContext (Context ctx, int w, int h) {
			this.PaintWidget(ctx,w,h);
		}
		public PointD MeasureSize () {
			double y = Margin;
			double x = 0.0d;
			foreach(QueryAnswerLocations qal in this.qas) {
				qal.Offset = new PointD(Margin,y);
				PointD sz = qal.MeasureSize(this.subcontext);
				y += sz.Y+Margin;
				x = Math.Max(x,sz.X);
			}
			x += 2.0d*Margin;
			return new PointD(x,y);
		}
		protected override void PaintWidget (Context ctx, int w, int h) {
			base.PaintWidget(ctx, w, h);
			ctx.Pattern = KnownColors.ConstructionPattern;
			ctx.Paint();
			ctx.Color = KnownColors.Black;
			foreach(QueryAnswerLocations qal in this.qas) {
				qal.Paint(ctx);
			}
		}
		private void AddQueryAnswer (QueryAnswerLocations qa) {
			if(qa != null) {
				QueryAnswerLocations qat = this.qas.Pop ();
				if(qat != null) {
					qat.BoundsChanged -= handleBoundsChanged;
				}
				this.qas.Push(qa);
				qa.BoundsChanged += handleBoundsChanged;
				this.handleBoundsChanged(this,EventArgs.Empty);
			}
		}

		private void handleBoundsChanged (object sender, EventArgs e) {
			double y = Margin;
			PointD siz = this.MeasureSize();
			this.SetSizeRequest((int) Math.Ceiling(siz.X),(int) Math.Ceiling(siz.Y));
			foreach(QueryAnswerLocations qal in this.qas) {
				qal.Offset = new PointD(Margin,y);
				y += qal.MeasureSize(this.subcontext).Y+Margin;
			}
		}
		public void ExecuteQuery ()
		{
			if (this.rootpiece != null && this.rootpiece.CanExecute) {
				try {
					IPuzzlePiece[] ans = this.resolver.Resolve (this.rootpiece);
					QueryAnswerLocations qal = new QueryAnswerLocations (this.rootpiece, ans);
					this.AddQueryAnswer (qal);
					qal = new QueryAnswerLocations(new RunPiece ());
					this.qas.Push(qal);
					qal.BoundsChanged += handleBoundsChanged;
					this.handleBoundsChanged(this,EventArgs.Empty);
					this.QueueDraw ();
				}
				catch (Exception e) {
					ExtensionMethods.ShowException(e);
				}
			} else {
				ExtensionMethods.ShowException("Cannot execute the query: not all required parameters have been resolved!");
			}
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

			public ITree<IPuzzlePiece> ChildAt (int index) {
					return this[index];
			}
			public IPuzzlePiece PieceParent {
				get {
					return null;
				}
				set {}
			}
			public IPuzzlePiece Data {
				get {
					return this;
				}
			}
			public int NumberOfChildren {
				get {
					return this.NumberOfArguments;
				}
			}
			public bool Complete {
				get {
					return true;
				}
			}
			public bool CanExecute {
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
					if(value != null) {
						throw new InvalidOperationException("Cannot set the values of a query answer!");
					}
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
			public event EventHandler Killed {add {} remove {}}

			private QueryAnswerLocations (RunPiece query, PointD offset, IPuzzlePiece[] answer, PointD[] locations) {
				this.query = query;
				this.offset = offset;
				this.answers = answer;
				this.locations = locations;
				this.registerChildren();
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
				int index = 0x00;
				foreach(IPuzzlePiece ipp in this.AllPieces()) {
					ipp.PieceParent = this;
					ipp.Index = index++;
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
						this.Locations[index++] = new PointD(size.X,0.0d);
						size.X += siz.X+Margin;
						size.Y = Math.Max(size.Y,siz.Y);
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
				this.MeasureSize (ctx);
				if (p.X < 0.0d && p.Y < 0.0d && p.X >= size.X || p.Y >= size.Y) {
					return null;
				} else {
					int index = 0x00;
					foreach(PointD l in Locations) {
						double dx = p.X-l.X;
						double dy = p.Y-l.Y;
						PointD siz = this[index].MeasureSize(ctx);
						if(dx >= 0.0d && dy >= 0.0d && dx <= siz.X && dy <= siz.Y) {
							p.X -= l.X;
							p.Y -= l.Y;
							return this[index].GetPuzzlePiece(ctx,p);
						}
						index++;
					}
					return null;
				}
			}
			public void MatchesConstraintsChildren (int index, IPuzzlePiece piece) {
			}
			public void MatchesConstraintsParent (IPuzzlePiece piece) {
			}
			public void InvalidateSizeCache ()
			{
				this.handleBoundsChanged(this,EventArgs.Empty);
			}
			public bool IsOptional (int index) {
				return false;
			}
			public bool Match (TypeBind tb) {
				return false;
			}
			public bool MatchBind (TypeBind tb, Dictionary<string,object> binddictionary) {
				return false;
			}
			public void Kill () {}

		}

	}

}