using System;
using System.Collections.Generic;
using Gtk;
using Cairo;

namespace DSLImplementation.UserInterface {

	public static class ExtensionMethods {

		public static bool Contains (this Rectangle rect, PointD p) {
			return p.X >= rect.X && p.Y >= rect.Y && p.X <= rect.X+rect.Width && p.Y <= rect.Y+rect.Height;
		}

		public static void ShowException (Exception e) {
			ShowException(e.Message+Environment.NewLine+e.ToString());
		}
		public static void ShowException (string message) {
			MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, message.Replace("<","&lt;").Replace(">","&gt;"));
			md.Run ();
			md.HideAll ();
			md.Dispose ();
		}
		public static T ValueOrDefault<TK,TV,T> (this Dictionary<TK,TV> dictionary, TK key) where T : TV
		{
			TV val;
			if (dictionary.TryGetValue (key, out val)) {
				if(val is T) {
					return (T) val;
				}
				else {
					return default(T);
				}
			} else {
				return default(T);
			}
		}
		public static void Rotate (ref double x, ref double y, double theta) {
			double cost = Math.Cos(theta);
			double sint = Math.Sin(theta);
			double nx = cost*x-sint*y;
			y = sint*x+cost*y;
			x = nx;
		}

		public static int IntegerBinaryLog (ulong x) {
			int l = 0x00;
			while(x > 0x01) {
				x >>= 0x01;
				l++;
			}
			return l;
		}
		public static int CountOnes (ulong x)
		{
			int ones = 0x00;
			while(x > 0x00) {
				ones += (int) (x&0x01);
				x >>= 0x01;
			}
			return ones;
		}

		public static bool IsTypeColorMatch (TypeColors tc1, TypeColors tc2) {
			return (tc1&tc2) > 0x00;
		}

		public static Pattern GenerateColorSequencePattern (double w, TypeColors colors) {
			Color[] clrs = new Color[CountOnes((ulong) colors)];
			ulong data = (ulong) colors;
			int index = 0x00;
			int i = 0x00;
			while(data > 0x00) {
				if((data&0x01) != 0x00) {
					clrs[index++] = KnownColors.GetColorFromColorType(i);
				}
				i++;
				data >>= 0x01;
			}
			return GenerateColorSequencePattern(w,clrs);
		}
		public static Pattern GenerateColorSequencePattern (double w, params Color[] colors) {
			int iw = (int) Math.Ceiling(w);
			double dw = (double) iw/colors.Length;
			ImageSurface imsu = new ImageSurface(Format.Argb32,iw,0x01);
			Context ctx = new Context(imsu);
			double x = 0.0d;
			foreach(Color c in colors) {
				ctx.Rectangle(x,0.0d,dw,1.0d);
				ctx.Color = c;
				ctx.Fill();
				x += dw;
			}
			Pattern pat = new SurfacePattern(imsu);
			pat.Extend = Extend.Repeat;
			((IDisposable) ctx).Dispose();
			return pat;
		}

	}
}

