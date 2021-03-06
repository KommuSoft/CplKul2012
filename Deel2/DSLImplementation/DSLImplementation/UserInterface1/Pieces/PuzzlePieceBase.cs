using System;
using System.Collections.Generic;
using System.Text;
using Cairo;
using DSLImplementation.Tiling;

namespace DSLImplementation.UserInterface {

	public abstract class PuzzlePieceBase : IPuzzlePiece {

		public const double Margin = 15.0d;
		public const double MinimumWidth = 64.0d;
		public const double MinimumHeight = 32.0d;
		public const string OptionalString = "(Optional)";
		private IPuzzlePiece[] arguments;
		private PointD sizeCache = new PointD(-1.0d,-1.0d);
		private EventHandler boundsChanged;
		private EventHandler killed;
		private Rectangle[] subpieces;
		private IPuzzlePiece parent;
		private int index = -0x01;

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
		public event EventHandler BoundsChanged {
			add {
				this.boundsChanged += value;
			}
			remove {
				this.boundsChanged -= value;
			}
		}
		public virtual string[] ArgumentNames {
			get {
				return null;
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
		public event EventHandler Killed {
			add {
				this.killed += value;
			}
			remove {
				this.killed -= value;
			}
		}
		public IPuzzlePiece PieceParent {
			get {
				return this.parent;
			}
			set {
				if(this.parent != value) {
					if(this.parent != null) {
						IPuzzlePiece parent = this.parent;
						this.parent = null;
						parent[index] = null;
					}
					this.parent = value;
					if(this.parent == null) {
						this.index = -0x01;
					}
				}
			}
		}
		public ITree<IPuzzlePiece> ChildAt (int index) {
			return this[index];
		}
		public virtual IPuzzlePiece this [int index] {
			get {
				return this.arguments [index];
			}
			set {
				if(value != null) {
					this.MatchesConstraintsChildren(index,value);
					value.MatchesConstraintsParent(this);
				}
				if(this.arguments[index] != value) {
					if(this.arguments[index] != null) {
						this.arguments[index].BoundsChanged -= this.PerformBoundsChanged;
					}
					this.arguments[index] = value;
					if(value != null) {
						value.Index = index;
						value.PieceParent = this;
						value.BoundsChanged += this.PerformBoundsChanged;
					}
					this.PerformBoundsChanged(this,EventArgs.Empty);
				}
				this.PerformChildrenChanged(this,EventArgs.Empty);
			}
		}
		public virtual string Name {
			get {
				string name = this.GetType().Name;
				if(name.EndsWith("Piece")) {
					name = name.Substring(0x00,name.Length-0x05);
				}
				return name;
			}
		}

		public virtual int NumberOfArguments {
			get {
				return this.TypeColorArguments.Length;
			}
		}
		public virtual int NumberOfOptionalArguments {
			get {
				return 0x00;
			}
		}
		public int NumberOfRequiredArguments {
			get {
				return this.NumberOfArguments-this.NumberOfOptionalArguments;
			}
		}
		public abstract TypeColors[] TypeColorArguments {
			get;
		}
		public bool IsLeaf {
			get {
				return this.NumberOfArguments <= 0x00;
			}
		}
		public abstract TypeColors TypeColors {
			get;
		}
		public virtual bool Complete {
			get {
				for(int i = 0; i < this.NumberOfRequiredArguments; i++) {
					if(this.arguments[i] == null || !this.arguments[i].Complete) {
						return false;
					}
				}
				return true;
			}
		}
		public virtual bool CanExecute {
			get {
				for(int i = 0; i < this.NumberOfRequiredArguments; i++) {
					if(this.arguments[i] == null || !this.arguments[i].CanExecute) {
						return false;
					}
				}
				return true;
			}
		}

		protected PuzzlePieceBase (params IPuzzlePiece[] pieces) : this() {
			int n = Math.Min(this.arguments.Length,pieces.Length);
			for(int i = 0x00; i < n; i++) {
				try {
					this[i] = pieces[i];
				}
				catch (Exception e) {

				}
			}
		}
		protected PuzzlePieceBase (IEnumerable<IPuzzlePiece> pieces) : this() {
			int index = 0x00;
			foreach(IPuzzlePiece ipp in pieces) {
				try {
					this[index] = ipp;
					index++;
				}
				catch (Exception e) {

				}
				if(index >= this.NumberOfArguments) {
					break;
				}
			}
		}
		protected PuzzlePieceBase () {
			this.arguments = new IPuzzlePiece[this.NumberOfArguments];
			this.subpieces = new Rectangle[this.NumberOfArguments];
		}

		protected void SetArgumentSize () {
			int nmin = Math.Min(this.arguments.Length,this.NumberOfArguments);
			IPuzzlePiece[] newarguments = new IPuzzlePiece[this.NumberOfArguments];
			Rectangle[] newsubpieces = new Rectangle[this.NumberOfArguments];
			for(int i = 0x00; i < nmin; i++) {
				newarguments[i] = this.arguments[i];
			}
			for(int i = nmin; i < this.arguments.Length; i++) {
				this[i] = null;
			}
			this.arguments = newarguments;
			this.subpieces = newsubpieces;
			this.PerformBoundsChanged(this,EventArgs.Empty);
		}

		public virtual void MatchesConstraintsChildren (int index, IPuzzlePiece piece)
		{
			if (!ExtensionMethods.IsTypeColorMatch (this.TypeColorArguments [index], piece.TypeColors)) {
				throw new ArgumentException(string.Format("The given piece doesn't match with it's parent: {0} versus {1}",piece.TypeColors,this.TypeColorArguments[index]));
			}
		}
		public virtual void MatchesConstraintsParent (IPuzzlePiece piece) {
		}
		public bool IsOptional (int index) {
			return index >= this.NumberOfArguments-this.NumberOfOptionalArguments;
		}

		protected virtual void PerformChildrenChanged (object s, EventArgs e) {
		}
		public void InvalidateSizeCache () {
			this.PerformBoundsChanged(this,EventArgs.Empty);
		}
		protected void PerformBoundsChanged (object s, EventArgs e) {
			sizeCache = new PointD(-1.0d,-1.0d);
			this.OnBoundsChanged(e);
			if(this.boundsChanged != null) {
				this.boundsChanged(this,e);
			}
		}
		protected virtual void OnBoundsChanged (EventArgs e) {}
		protected void PaintContour (Context ctx, PointD size) {
			ctx.Rectangle (0.0d, 0.0d, size.X, size.Y);
			ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern (size.X, this.TypeColors);
			ctx.FillPreserve ();
			ctx.Color = KnownColors.Black;
			ctx.Stroke ();
		}
		#region IPuzzlePiece implementation
		public virtual void Paint (Context ctx) {
			PointD size = this.MeasureSize (ctx);
			PaintContour (ctx,size);
			KnownColors.SetFontFacePieceName(ctx);
			TextExtents te = ctx.TextExtents(this.Name), ten;
			double y0 = 0.5d*(size.Y-te.Width);
			ctx.MoveTo(0.5d*Margin,y0);
			ctx.Save();
			ctx.Rotate(0.5d*Math.PI);
			ctx.ShowText(this.Name);
			ctx.Restore();
			double x0 = Margin+te.Height;
			KnownColors.SetFontFaceNormal(ctx);
			te = ctx.TextExtents(OptionalString);
			y0 = 2.0d*Margin;
			int index = 0x00;
			PointD siz;
			foreach(IPuzzlePiece ipp in this.arguments) {
				ctx.Save();
				ctx.Translate(x0,Margin);
				if(ipp == null) {
					siz = new PointD(MinimumWidth,size.Y-4.0d*Margin);
					ctx.Rectangle(Margin,Margin,siz.X,siz.Y);
					ctx.Pattern = KnownColors.ConstructionPattern;
					ctx.FillPreserve();
				}
				else {
					siz = ipp.MeasureSize(ctx);
				}
				ctx.Rectangle(0.0d,0.0d,siz.X+2.0d*Margin,siz.Y+2.0d*Margin);
				ctx.Color = KnownColors.Black;
				ctx.StrokePreserve();
				if(ipp == null) {
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(siz.X+2.0d*Margin,TypeColorArguments[index]);
					ctx.Fill();
					ctx.Translate(Margin,Margin);
					ctx.MoveTo(0.0d,0.0d);
					ctx.LineTo(MinimumWidth,0.0d);
					ctx.RelLineTo(0.0d,5.0d);
					ctx.LineTo(5.0d,5.0d);
					ctx.ClosePath();
					ctx.Pattern = KnownColors.ShadowDownPattern;
					ctx.Fill();
					ctx.MoveTo(0.0d,0.0d);
					ctx.LineTo(0.0d,siz.Y);
					ctx.RelLineTo(5.0d,0.0d);
					ctx.LineTo(5.0d,5.0d);
					ctx.ClosePath();
					ctx.Pattern = KnownColors.ShadowRightPattern;
					ctx.Fill();
				}
				else {
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(siz.X+2.0d*Margin,TypeColorArguments[index]);
					ctx.Fill();
					ctx.Color = KnownColors.Black;
					ctx.Translate(Margin,Margin);
					ipp.Paint(ctx);
				}
				ctx.Restore();
				subpieces[index] = new Rectangle(x0+Margin,2.0d*Margin,siz.X,siz.Y);
				x0 += siz.X+3.0d*Margin;
				if(index >= NumberOfArguments-NumberOfOptionalArguments) {
					ctx.MoveTo(x0-2.0d*Margin-0.5d*(siz.X+te.Width),siz.Y+3.0d*Margin-2.0d);
					ctx.ShowText(OptionalString);
				}
				if(this.ArgumentNames != null && index < arguments.Length) {
					ten = ctx.TextExtents(this.ArgumentNames[index]);
					ctx.MoveTo(x0-2.0d*Margin-0.5d*(siz.X+ten.Width),-te.YBearing+Margin+2.0d);
					ctx.ShowText(this.ArgumentNames[index]);
				}
				index++;
			}
		}

		public virtual PointD MeasureSize (Context ctx)
		{
			if(sizeCache.X < 0.0d) {
				double w, th, h = MinimumHeight;
				KnownColors.SetFontFacePieceName(ctx);
				TextExtents te = ctx.TextExtents(this.Name);
				PointD siz;
				w = te.Height+Margin;
				th = te.Width;
				int index = 0x00;
				foreach(IPuzzlePiece piece in this.arguments) {
					if(piece == null) {
						siz = new PointD(MinimumWidth,MinimumHeight);
					}
					else {
						siz = piece.MeasureSize(ctx);
						h = Math.Max(h,siz.Y);
					}
					this.subpieces[index++] = new Rectangle(w,2.0d*Margin,siz.X,siz.Y);
					w += siz.X+3.0d*Margin;
				}
				this.sizeCache = new PointD(w,Math.Max(th,h+2.0d*Margin)+2.0d*Margin);
			}
			return this.sizeCache;
		}
		public PointD ChildLocation (Context ctx,int index) {
			if(sizeCache.X < 0.0d) {
				MeasureSize(ctx);
			}
			Rectangle r = this.subpieces[index];
			return new PointD(r.X,r.Y);
		}
		public PointD InnerLocation (Context ctx) {
			if (parent != null) {
				return this.parent.ChildLocation(ctx,index);
			} else {
				return new PointD(0.0d,0.0d);
			}
		}
		public PointD OuterLocation (Context ctx) {
			if (parent != null) {
				PointD dxy = this.parent.OuterLocation(ctx);
				PointD off = this.parent.ChildLocation(ctx,index);
				return new PointD(off.X+dxy.X,off.Y+dxy.Y);
			} else {
				return new PointD(0.0d,0.0d);
			}
		}
		public IPuzzlePiece GetPuzzleGap (Context ctx, PointD location, out int index)
		{
			PointD size = this.MeasureSize (ctx);
			if (location.X >= size.X || location.Y >= size.Y) {
				index = -0x01;
				return null;
			} else {
				index = 0x00;
				foreach(Rectangle r in subpieces) {
					if(r.Contains(location)) {
						if(this[index] == null) {
							return this;
						}
						else {
							location.X -= r.X;
							location.Y -= r.Y;
							return this[index].GetPuzzleGap(ctx,location,out index);
						}
					}
					index++;
				}
				index = -0x01;
				return null;
			}
		}
		public IPuzzlePiece GetPuzzlePiece (Context ctx, PointD location) {
			PointD size = this.MeasureSize (ctx);
			if (location.X >= size.X || location.Y >= size.Y) {
				return null;
			} else {
				int index = 0x00;
				foreach(Rectangle r in subpieces) {
					if(r.Contains(location) && this[index] != null) {
						location.X -= r.X;
						location.Y -= r.Y;
						return this[index].GetPuzzlePiece(ctx,location);
					}
					index++;
				}
				return this;
			}
		}
		#endregion

		public virtual bool Match (TypeBind tb) {
			return (tb.Type.IsAssignableFrom(this.GetType()));
		}
		public virtual bool MatchBind (TypeBind tb, Dictionary<string,object> binddictionary) {
			return (tb.Type.IsAssignableFrom(this.GetType()));
		}

		public override bool Equals (object obj) {
			if(obj == null) {
				return false;
			}
			if(this.GetType().Equals(obj.GetType())) {
				PuzzlePieceBase ipp = (PuzzlePieceBase) obj;
				if(this.Name == ipp.Name && this.NumberOfArguments == ipp.NumberOfArguments) {
					for(int i = 0x00; i < this.NumberOfArguments; i++) {
						if(this[i] != null && !this[i].Equals(ipp[i])) {
							return false;
						}
						else if(ipp[i] != null) {
							return false;
						}
					}
					return true;
				}
				return false;
			}
			return base.Equals (obj);
		}

		public void Kill () {
			if(this.killed != null) {
				this.killed(this,EventArgs.Empty);
			}
		}

		public override string ToString () {
			if (this.arguments != null && this.arguments.Length > 0x00) {
				StringBuilder sb = new StringBuilder();
				foreach(IPuzzlePiece ipp in this.arguments) {
					if(ipp != null) {
						sb.Append(string.Format(",{0}",ipp.ToString()));
					}
				}
				return string.Format ("[{0}({1})]", GetType().Name,sb.ToString());
			} else {
				return string.Format("[{0}]",GetType().Name);
			}
		}

	}
}

