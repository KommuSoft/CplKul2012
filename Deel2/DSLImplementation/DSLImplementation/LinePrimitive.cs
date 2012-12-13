using System;
using Cairo;

namespace DSLImplementation {

	public class LinePrimitive : IPaintPrimitive {

		private PointD frm;
		private PointD to;

		public LinePrimitive (PointD frm, PointD to) {
			this.frm = frm;
			this.to = to;
		}

		#region IPaintPrimitive implementation
		public double Score (System.Collections.Generic.List<PointD> points, out IPaintPrimitive primitive) {
			PointD frm = points[0];
			PointD to = points[points.Count-1];
			primitive = new LinePrimitive(frm, to);
			double dx = to.X-frm.X;
			double dy = to.Y-frm.Y;
			double score = 0.0d, d;
			foreach(PointD p in points) {
				d = dy*(p.X-frm.X)+dx*(p.Y-frm.X);
				score += d*d;
			}
			return points.Count/score;
		}

		public void Paint (Context ctx) {
			ctx.MoveTo(frm);
			ctx.LineTo(to);
			ctx.Stroke();
		}
		#endregion


	}
}

