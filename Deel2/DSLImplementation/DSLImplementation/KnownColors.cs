using Cairo;

namespace DSLImplementation.UserInterface {

	public static class KnownColors {


		public const int ConstructionDelta = 0x08;
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
					ctx.Color = new Color(0.75d,0.75d,0.75d);
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

	}

}