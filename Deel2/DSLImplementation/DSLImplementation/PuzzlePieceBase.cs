using System;
using System.Collections.Generic;
using Cairo;

namespace DSLImplementation.UserInterface {

	public abstract class PuzzlePieceBase : IPuzzlePiece {

		public const double Margin = 15.0d;
		public const double MinimumWidth = 64.0d;
		public const double MinimumHeight = 32.0d;
		public const string OptionalString = "(Optional)";
		private readonly IPuzzlePiece[] arguments;
		private PointD sizeCache = new PointD(-1.0d,-1.0d);
		private EventHandler boundsChanged;
		private readonly Rectangle[] subpieces;

		public event EventHandler BoundsChanged {
			add {
				this.boundsChanged += value;
			}
			remove {
				this.boundsChanged -= value;
			}
		}
		public IPuzzlePiece this [int index] {
			get {
				return this.arguments [index];
			}
			set {
				if(!this.MatchesConstraints(index,value)) {
					throw new ArgumentException("The given piece doesn't match with it's parent.");
				}
				if(this.arguments[index] != value) {
					if(this.arguments[index] != null) {
						this.arguments[index].BoundsChanged -= this.performBoundsChanged;
					}
					this.arguments[index] = value;
					if(this.arguments[index] != null) {
						this.arguments[index].BoundsChanged += this.performBoundsChanged;
					}
					this.performBoundsChanged(this,EventArgs.Empty);
				}
			}
		}
		public string Name {
			get {
				string name = this.GetType().Name;
				if(name.EndsWith("Piece")) {
					name = name.Substring(0x00,name.Length-0x05);
				}
				return name;
			}
		}

		public int NumberOfArguments {
			get {
				return this.TypeColorArguments.Length;
			}
		}
		public virtual int NumberOfOptionalArguments {
			get {
				return 0x00;
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


		protected PuzzlePieceBase (params IPuzzlePiece[] pieces) : this() {
			int n = Math.Min(this.arguments.Length,pieces.Length);
			for(int i = 0x00; i < n; i++) {
				try {
					this[i] = pieces[i];
				}
				catch (Exception e) {
					Console.Error.WriteLine(e);
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
					Console.Error.WriteLine(e);
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

		public virtual bool MatchesConstraints (int index, IPuzzlePiece piece)
		{
			return ExtensionMethods.IsTypeColorMatch(this.TypeColorArguments[index],piece.TypeColors);
		}
		public bool IsOptional (int index) {
			return index >= this.NumberOfArguments-this.NumberOfOptionalArguments;
		}
		private void performBoundsChanged (object s, EventArgs e) {
			sizeCache = new PointD(-1.0d,-1.0d);
			this.OnBoundsChanged(e);
			if(this.boundsChanged != null) {
				this.boundsChanged(this,e);
			}
		}
		protected virtual void OnBoundsChanged (EventArgs e) {}
		#region IPuzzlePiece implementation
		public void Paint (Context ctx) {
			PointD size = this.MeasureSize(ctx);
			ctx.Rectangle(0.0d,0.0d,size.X,size.Y);
			ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(size.X,this.TypeColors);
			ctx.FillPreserve();
			ctx.Color = KnownColors.Black;
			ctx.Stroke();
			TextExtents te = ctx.TextExtents(this.Name);
			double y0 = 0.5d*(size.Y-te.Height);
			ctx.MoveTo(Margin,y0);
			ctx.ShowText(this.Name);
			double x0 = 2.0d*Margin+te.Width;
			te = ctx.TextExtents(OptionalString);
			y0 = 2.0d*Margin;
			int index = 0x00;
			PointD siz;
			foreach(IPuzzlePiece ipp in this.arguments) {
				ctx.Save();
				ctx.Translate(x0,Margin);
				if(ipp == null) {
					siz = new PointD(MinimumWidth,MinimumHeight);
					ctx.Rectangle(Margin,Margin,MinimumWidth,MinimumHeight);
					ctx.Pattern = KnownColors.ConstructionPattern;
					ctx.FillPreserve();
					ctx.Rectangle(0.0d,0.0d,MinimumWidth+2.0d*Margin,MinimumHeight+2.0d*Margin);
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(MinimumWidth+2.0d*Margin,TypeColorArguments[index]);
					ctx.FillPreserve();
					ctx.Color = KnownColors.Black;
					ctx.Stroke();
				}
				else {
					siz = ipp.MeasureSize(ctx);
					ctx.Rectangle(0.0d,0.0d,siz.X+2.0d*Margin,siz.Y+2.0d*Margin);
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(MinimumWidth+2.0d*Margin,TypeColorArguments[index]);
					ctx.FillPreserve();
					ctx.Color = KnownColors.Black;
					ctx.Stroke();
					ctx.Translate(Margin,Margin);
					ipp.Paint(ctx);
				}
				ctx.Restore();
				subpieces[index] = new Rectangle(x0+Margin,Margin,siz.X,siz.Y);
				x0 += siz.X+3.0d*Margin;
				if(index >= NumberOfArguments-NumberOfOptionalArguments) {
					ctx.MoveTo(x0-2.0d*Margin-0.5d*(siz.X+te.Width),size.Y-0.5d*te.Height);
					ctx.ShowText(OptionalString);
				}
				index++;
			}
		}

		public PointD MeasureSize (Context ctx)
		{
			if(sizeCache.X < 0.0d) {
				double w, th, h = MinimumHeight;
				TextExtents te = ctx.TextExtents(this.Name);
				w = te.Width+2.0d*Margin;
				th = te.Height;
				foreach(IPuzzlePiece piece in this.arguments) {
					if(piece == null) {
						w += MinimumWidth+3.0d*Margin;
					}
					else {
						PointD size = piece.MeasureSize(ctx);
						w += size.X+3.0d*Margin;
						h = Math.Max(h,size.Y);
					}
				}
				this.sizeCache = new PointD(w,Math.Max(th,h+2.0d*Margin)+2.0d*Margin);
			}
			return this.sizeCache;
		}
		public IPuzzlePiece GetPuzzleGap (Context ctx, PointD location, out int index)
		{
			PointD size = this.MeasureSize (ctx);
			if (location.X >= size.X || location.Y >= size.Y) {
				index = -0x01;
				return null;
			} else {
				//TODO: Make O(log n)
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
		#endregion

	}
}

