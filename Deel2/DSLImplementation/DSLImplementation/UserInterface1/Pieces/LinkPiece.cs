using System;
using System.Collections.Generic;
using Cairo;
using DSLImplementation.Tiling;

namespace DSLImplementation.UserInterface {

	public class LinkPiece : KeyValueTableZeroArgumentPuzzlePieceBase {

		private readonly IPuzzlePiece piece;

		public override string Name {
			get {
				return string.Empty;
			}
		}
		public IPuzzlePiece Piece {
			get {
				return this.piece;
			}
		}
		public override bool CanExecute {
			get {
				if(this.Piece != null) {
					return this.Piece.CanExecute;
				}
				else {
					return false;
				}
			}
		}
		public override bool Complete {
			get {
				if(this.Piece != null) {
					return this.Piece.Complete;
				}
				else {
					return false;
				}
			}
		}
		public override int NumberOfArguments {
			get {
				if(this.piece != null) {
					return this.piece.NumberOfArguments;
				}
				else {
					return 0x00;
				}
			}
		}
		public override TypeColors TypeColors {
			get {
				return this.piece.TypeColors;
			}
		}
		public override IPuzzlePiece this[int index] {
			get {
				return this.piece[index];
			}
			set {
				this.piece[index] = value;
			}
		}

		public LinkPiece (IPuzzlePiece piece) {
			this.piece = piece;
		}

		public override PointD MeasureSize (Context ctx) {
			return new PointD(PuzzlePieceBase.MinimumWidth,PuzzlePieceBase.MinimumHeight);
		}
		public override void Paint (Context ctx) {
			PointD siz = this.MeasureSize(ctx);
			this.PaintContour(ctx,siz);
			PointD l = new PointD(0.5d*siz.X,0.5d*siz.Y);
			ctx.Arc(l.X,l.Y,2.0d,0.0d,2.0d*Math.PI);
			ctx.Color = KnownColors.LinkColor;
			ctx.Fill();
			ctx.MoveTo(l.X,l.Y);
			ctx.IdentityMatrix();
			siz = this.piece.OuterLocation(ctx);
			PointD siza = this.piece.MeasureSize(ctx);
			ctx.LineTo(siz.X+0.5d*siza.X,siz.Y+0.5d*siza.Y);
			ctx.Stroke();
			ctx.Color = KnownColors.Black;
		}
		public override void MatchesConstraintsParent (IPuzzlePiece piece)
		{
			IPuzzlePiece par = piece;
			while (par != null && par != this.piece) {
				par = par.PieceParent;
			}
			if (par == null) {
				base.MatchesConstraintsParent (piece);
			} else {
				throw new Exception("Cyclic relations are not allowed!");
			}
		}
		public override bool Match (TypeBind tb)
		{
			if (this.Piece != null) {
				return this.Piece.Match (tb);
			} else {
				return false;
			}
		}
		public override bool MatchBind (TypeBind tb, Dictionary<string, object> binddictionary) {
			if (this.Piece != null) {
				return this.Piece.MatchBind (tb,binddictionary);
			} else {
				return false;
			}
		}

	}

}