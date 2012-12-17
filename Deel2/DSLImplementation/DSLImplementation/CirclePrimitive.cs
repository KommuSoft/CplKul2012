//
//  CirclePrimitive.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2012 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using Cairo;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.LinearAlgebra.Double.Factorization;

namespace DSLImplementation {

	public class CirclePrimitive : IPaintPrimitive {

		private PointD center;
		private double radius;

		public CirclePrimitive (PointD center, double radius) {
			this.center = center;
			this.radius = radius;
		}

		#region IPaintPrimitive implementation
		public double Score (List<PointD> points, out IPaintPrimitive primitive) {
			double[,] matrix = new double[points.Count, 3];
			double[,] inputs = new double[points.Count, 1];
			int i = 0;
			foreach(PointD p in points) {
				matrix[i, 0] = p.X;
				matrix[i, 1] = p.Y;
				matrix[i, 2] = 1.0d;
				inputs[i++, 0] = p.X*p.X+p.Y*p.Y;
			}
			DenseMatrix dm = new DenseMatrix(matrix);
			DenseQR dqr = new DenseQR(dm, MathNet.Numerics.LinearAlgebra.Generic.Factorization.QRMethod.Full);
			MatrixStorage<double> ms = dqr.Solve(new DenseMatrix(inputs)).Storage;
			double d = ms.At(0, 0);
			double e = ms.At(1, 0);
			double f = ms.At(2, 0);
			double x0 = 0.5d*d;
			double y0 = 0.5d*e;
			double r = Math.Sqrt(x0*x0+y0*y0+f);
			PointD center = new PointD(x0, y0);
			primitive = new CirclePrimitive(center, r);
			double score = 0.0d;
			double dx, dy;
			foreach(PointD p in points) {
				dx = p.X-x0;
				dy = p.X-x0;
				d = Math.Sqrt(Math.Abs(dx*dx+dy*dy-r*r));
				score += d*d;
			}
			return points.Count/score;
		}

		public void Paint (Context ctx) {
			ctx.Arc(center.X, center.Y, radius, 0.0d, 2.0d*Math.PI);
			ctx.Stroke();
		}
		#endregion




	}
}

