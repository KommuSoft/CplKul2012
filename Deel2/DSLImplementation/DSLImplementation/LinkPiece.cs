using System;
using Cairo;

namespace DSLImplementation.UserInterface {

	public class LinkPiece : KeyValueTableZeroArgumentPuzzlePieceBase<string,string> {

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

		public override TypeColors TypeColors {
			get {
				return this.piece.TypeColors;
			}
		}

		public LinkPiece (IPuzzlePiece piece) {
			this.piece = piece;
		}

		public override void Paint (Context ctx) {
			base.Paint (ctx);
			PointD siz = this.MeasureSize(ctx);
			PointD l = new PointD(0.5d*siz.X,0.5d*siz.Y);
			ctx.Arc(l.X,l.Y,2.0d,0.0d,2.0d*Math.PI);
			ctx.Color = KnownColors.DarkRed;
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

	}

}