using System;
using Cairo;

namespace DSLImplementation.UserInterface {

	public class LinkPiece : ZeroArgumentPuzzlePieceBase {

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
			ctx.Fill();
			ctx.MoveTo(l.X,l.Y);
			ctx.IdentityMatrix();
			siz = this.piece.OuterLocation(ctx);
			Console.WriteLine("{0}/{1}",siz.X,siz.Y);
			ctx.LineTo(siz);
			ctx.Stroke();
		}

	}

}