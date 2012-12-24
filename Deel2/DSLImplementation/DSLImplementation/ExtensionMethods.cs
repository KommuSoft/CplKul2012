using System;
using Cairo;

namespace DSLImplementation
{
	public static class ExtensionMethods {

		public static bool Contains (this Rectangle rect, PointD p) {
			return p.X >= rect.X && p.Y >= rect.Y && p.X <= rect.X+rect.Width && p.Y <= rect.Y+rect.Height;
		}

		public static void Rotate (ref double x, ref double y, double theta) {
			double cost = Math.Cos(theta);
			double sint = Math.Sin(theta);
			double nx = cost*x-sint*y;
			y = sint*x+cost*y;
			x = nx;
		}

	}
}

