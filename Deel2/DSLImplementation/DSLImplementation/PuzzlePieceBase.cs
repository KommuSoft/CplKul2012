using System;
using System.Collections.Generic;
using Cairo;

namespace DSLImplementation.UserInterface {

	public abstract class PuzzlePieceBase : IPuzzlePiece {

		public const double Margin = 10.0d;
		public const double MinimumWidth = 64.0d;
		public const double MinimumHeight = 32.0d;
		private IPuzzlePiece[] arguments;

		public IPuzzlePiece this [int index] {
			get {
				return this.arguments [index];
			}
			set {
				if(!this.MatchesConstraints(index,value)) {
					throw new ArgumentException("The given piece doesn't match with it's parent.");
				}
				this.arguments[index] = value;
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
		}

		public virtual bool MatchesConstraints (int index, IPuzzlePiece piece)
		{
			return ExtensionMethods.IsTypeColorMatch(this.TypeColorArguments[index],piece.TypeColors);
		}
		public bool IsOptional (int index) {
			return index >= this.NumberOfArguments-this.NumberOfOptionalArguments;
		}

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
			y0 = 2.0d*Margin;
			int index = 0x00;
			foreach(IPuzzlePiece ipp in this.arguments) {
				if(ipp == null) {
					ctx.Save();
					ctx.Translate(x0,Margin);
					ctx.Rectangle(Margin,Margin,MinimumWidth,MinimumHeight);
					ctx.Pattern = KnownColors.ConstructionPattern;
					ctx.FillPreserve();
					ctx.Rectangle(0.0d,0.0d,MinimumWidth+2.0d*Margin,MinimumHeight+2.0d*Margin);
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern(MinimumWidth+2.0d*Margin,TypeColorArguments[index]);
					ctx.FillPreserve();
					ctx.Color = KnownColors.Black;
					ctx.Stroke();
					ctx.Restore();
					x0 += MinimumWidth+3.0d*Margin;
				}
				else {
					ctx.Save();
					ctx.Translate(x0,y0);
					ipp.Paint(ctx);
					ctx.Restore();
				}
				index++;
			}
		}

		public PointD MeasureSize (Context ctx)
		{
			double w, th, h = MinimumHeight;
			TextExtents te = ctx.TextExtents(this.Name);
			w = te.Width;
			th = te.Height;
			foreach(IPuzzlePiece piece in this.arguments) {
				if(piece == null) {
					w += MinimumWidth;
				}
				else {
					PointD size = piece.MeasureSize(ctx);
					w += size.X;
					h = Math.Max(h,size.Y);
				}
			}
			double px = (2.0d+3.0d*this.NumberOfArguments)*Margin;
			return new PointD(px+w,Math.Max(th,h+2.0d*Margin)+2.0d*Margin);
		}
		#endregion

	}
}

