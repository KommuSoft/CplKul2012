using System;
using Cairo;

namespace DSLImplementation.UserInterface {

	public static class KnownColors {


		public const int ConstructionDelta = 0x40;
		public static readonly Color Blue = GenerateHTMLColor(0x0000AA);
		public static readonly Color Green = GenerateHTMLColor(0x00AA00);
		public static readonly Color Cyan = GenerateHTMLColor(0x00AAAA);
		public static readonly Color Red = GenerateHTMLColor(0xAA0000);
		public static readonly Color Magenta = GenerateHTMLColor(0xAA00AA);
		public static readonly Color Brown = GenerateHTMLColor(0xAA5500);
		public static readonly Color LightGray = GenerateHTMLColor(0xAAAAAA);
		public static readonly Color DarkGray = GenerateHTMLColor(0x555555);
		public static readonly Color BrightBlue = GenerateHTMLColor(0x5555FF);
		public static readonly Color BrightGreen = GenerateHTMLColor(0x55FF55);
		public static readonly Color BrightCyan = GenerateHTMLColor(0x55FFFF);
		public static readonly Color BrightRed = GenerateHTMLColor(0xFF5555);
		public static readonly Color BrightMagenta = GenerateHTMLColor(0xFF55FF);
		public static readonly Color BrightYellow = GenerateHTMLColor(0xFFFF55);
		public static readonly Color White = GenerateHTMLColor(0xFFFFFF);
		public static readonly Color Orange = GenerateHTMLColor(0xFFA500);
		public static readonly Color Purple = GenerateHTMLColor(0xA020F0);
		public static readonly Color Black	= new Color(0.0d,0.0d,0.0d);
		public static readonly Color LinkColor	= new Color(0.25d,0.0d,0.0d);
		private static readonly Color[] colors = new Color[] {Blue,Green,Cyan,Red,Magenta,Brown,LightGray,DarkGray,BrightBlue,BrightGreen,BrightCyan,BrightRed,BrightMagenta,BrightYellow,White,Orange,Purple};
		private static Pattern constructionPattern = null, shadowd = null, shadowr = null;

		public static Pattern ShadowDownPattern {
			get {
				if(shadowd == null) {
					LinearGradient lg = new LinearGradient(0.0d,0.0d,0.0d,5.0d);
					for(int i = 0x00; i <= 0x32; i++) {
						lg.AddColorStop(0.02d*i,new Color(0.0d,0.0d,0.0d,1.0d-0.02d*i));
					}
					lg.Extend = Extend.Pad;
					shadowd = lg;
				}
				return shadowd;
			}
		}
		public static Color GenerateHTMLColor (int color)
		{
			int r = color>>0x10;
			int g = (color>>0x08)&0xff;
			int b = color&0xff;
			return new Color(r/255.0d,g/255.0d,b/255.0d);
		}
		public static Pattern ShadowRightPattern {
			get {
				if(shadowr == null) {
					LinearGradient lg = new LinearGradient(0.0d,0.0d,5.0d,0.0d);
					for(int i = 0x00; i <= 0x32; i++) {
						lg.AddColorStop(0.02d*i,new Color(0.0d,0.0d,0.0d,1.0d-0.02d*i));
					}
					lg.Extend = Extend.Pad;
					shadowr = lg;
				}
				return shadowr;
			}
		}
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
					ctx.Color = new Color(0.125d,0.125d,0.0083d);
					ctx.Fill();
					constructionPattern = new SurfacePattern(imsu);
					constructionPattern.Extend = Extend.Repeat;
					((IDisposable) ctx).Dispose();
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
		public static void SetFontFaceNormal (Context ctx) {
			ctx.SelectFontFace("Arial",FontSlant.Normal,FontWeight.Normal);
			ctx.SetFontSize(12.0d);
		}
		public static void SetFontFacePieceName (Context ctx)
		{
			ctx.SelectFontFace("Arial",FontSlant.Italic,FontWeight.Bold);
			ctx.SetFontSize(14.0d);
		}
		public static Gdk.Pixbuf GeneratePuzzlePiece (TypeColors tc, int size)
		{
			Gdk.Pixbuf pb;
			using (ImageSurface imsu = new ImageSurface (Format.ARGB32, size, size)) {
				using (Context ctx = new Context (imsu)) {
					ctx.Color = White;
					ctx.Paint ();
					double x1 = 0.9d * size, x0 = size - x1, x2 = 0.35d * size, x3 = 0.55d * size, x4 = 0.45d * size;
					ctx.MoveTo (0.0d, x0);
					ctx.LineTo (x2, x0);
					ctx.Arc (x4, x0, x0, Math.PI, 2.0d * Math.PI);
					ctx.LineTo (x1, x0);
					ctx.LineTo (x1, x2 + x0);
					ctx.Arc (x1, x4 + x0, x0, 1.5d * Math.PI, 2.5d * Math.PI);
					ctx.LineTo (x1, size);
					ctx.LineTo (x3, size);
					ctx.ArcNegative (x4, size, x0, 2.0d * Math.PI, Math.PI);
					ctx.LineTo (0.0d, size);
					ctx.LineTo (0.0d, x3 + x0);
					ctx.ArcNegative (0.0d, x4 + x0, x0, 2.5d * Math.PI, 1.5d * Math.PI);
					ctx.ClosePath ();
					ctx.Pattern = ExtensionMethods.GenerateColorSequencePattern (size, tc);
					ctx.Fill ();
					byte a, r, g, b;
					byte[] dat = new byte[imsu.Data.Length];
					for (int i = 0, j = 0; i < dat.Length;) {
						b = imsu.Data [i++];
						g = imsu.Data [i++];
						r = imsu.Data [i++];
						a = imsu.Data [i++];
						dat [j++] = r;
						dat [j++] = g;
						dat [j++] = b;
						dat [j++] = a;
					}
					pb = new Gdk.Pixbuf(dat,Gdk.Colorspace.Rgb,true,8,size,size,imsu.Stride);
				}
			}
			return pb;
		}

	}

}