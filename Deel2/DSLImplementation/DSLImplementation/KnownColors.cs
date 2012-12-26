using System;
using Cairo;

namespace DSLImplementation.UserInterface {

	public static class KnownColors {


		public const int ConstructionDelta = 0x20;
		public static readonly Color Red	= new Color(1.0d,0.5d,0.5d);
		public static readonly Color Green	= new Color(0.5d,1.0d,0.5d);
		public static readonly Color Blue	= new Color(0.5d,0.5d,1.0d);
		public static readonly Color Yellow	= new Color(1.0d,1.0d,0.5d);
		public static readonly Color Purple	= new Color(0.75d,0.5d,0.75d);
		public static readonly Color Orange	= new Color(1.0d,0.75d,0.5d);
		public static readonly Color White	= new Color(1.0d,1.0d,1.0d);
		public static readonly Color Black	= new Color(0.0d,0.0d,0.0d);
		private static readonly Color[] colors = new Color[] {Red,Green,Blue,Yellow,Purple,Orange,White};
		private static Pattern constructionPattern = null;

		public static Pattern ConstructionPattern {
			get {
				if(constructionPattern == null) {
					ImageSurface imsu = new ImageSurface(Format.Argb32,ConstructionDelta,ConstructionDelta);
					Context ctx = new Context(imsu);
					ctx.Color = new Color(0.25d,0.25d,0.25d);
					ctx.Paint();
					ctx.MoveTo(0.0d,0.0d);
					ctx.LineTo(0.25d*ConstructionDelta,0.0d);
					ctx.RelLineTo(0.75d*ConstructionDelta,0.75d*ConstructionDelta);
					ctx.RelLineTo(0.0d,0.25d*ConstructionDelta);
					ctx.RelLineTo(-0.25d*ConstructionDelta,0.0d);
					ctx.RelLineTo(-0.75d*ConstructionDelta,-0.75d*ConstructionDelta);
					ctx.ClosePath();
					ctx.MoveTo(0.75d*ConstructionDelta,0.0d);
					ctx.RelLineTo(0.25d*ConstructionDelta,0.25d*ConstructionDelta);
					ctx.RelLineTo(0.0d,-0.25d*ConstructionDelta);
					ctx.ClosePath();
					ctx.MoveTo(0.0d,0.75d*ConstructionDelta);
					ctx.RelLineTo(0.25d*ConstructionDelta,0.25d*ConstructionDelta);
					ctx.RelLineTo(-0.25d*ConstructionDelta,0.0d);
					ctx.ClosePath();
					ctx.Color = new Color(0.75d,0.75d,0.25d);
					ctx.Fill();
					constructionPattern = new SurfacePattern(imsu);
					constructionPattern.Extend = Extend.Repeat;
				}
				return constructionPattern;
			}
		}

		public static Color GetColorFromColorType (TypeColors tc) {
			return colors[ExtensionMethods.IntegerBinaryLog((ulong) tc)];
		}
		public static Color GetColorFromColorType (int index) {
			return colors[index];
		}
		public static Gdk.Pixbuf GeneratePuzzlePiece (TypeColors tc, int size)
		{
			ImageSurface imsu = new ImageSurface(Format.ARGB32,size,size);
			Context ctx = new Context (imsu);
				//Gdk.Pixbuf pb = new Gdk.Pixbuf(Gdk.Colorspace.Rgb,true,8,size,size);
				//Context ctx = Gdk.CairoHelper.Create(pb);
			ctx.Color = White;
			ctx.Paint();
			double x1 = 0.9d * size, x0 = size - x1, x2 = 0.35d * size, x3 = 0.55d * size, x4 = 0.45d * size;
			ctx.MoveTo (0.0d, x0);
			ctx.LineTo (x2, x0);
			ctx.Arc (x4, x0, x0, Math.PI, 2.0d*Math.PI);
			ctx.LineTo(x1,x0);
			ctx.LineTo (x1, x2+x0);
			ctx.Arc (x1, x4+x0, x0, 1.5d*Math.PI, 2.5d*Math.PI);
			ctx.LineTo(x1,size);
			ctx.LineTo(x3,size);
			ctx.ArcNegative (x4, size, x0, 2.0d*Math.PI, Math.PI);
			ctx.LineTo(0.0d,size);
			ctx.LineTo(0.0d,x3+x0);
			ctx.ArcNegative(0.0d, x4+x0, x0, 2.5d*Math.PI, 1.5d*Math.PI);
			ctx.ClosePath();
			ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern (size, tc);
			ctx.Fill();
			byte a, r, g, b;
			byte[] dat = new byte[imsu.Data.Length];
			for(int i = 0, j = 0; i < dat.Length;) {
				b = imsu.Data[i++];
				g = imsu.Data[i++];
				r = imsu.Data[i++];
				a = imsu.Data[i++];
				dat[j++] = r;
				dat[j++] = g;
				dat[j++] = b;
				dat[j++] = a;
			}
			return new Gdk.Pixbuf(dat,Gdk.Colorspace.Rgb,true,8,size,size,imsu.Stride);
		}

	}

}