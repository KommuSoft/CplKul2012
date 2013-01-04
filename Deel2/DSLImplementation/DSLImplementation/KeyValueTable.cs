using System;
using System.Collections.Generic;
using Cairo;

namespace DSLImplementation.UserInterface {

	public class KeyValueTable<TKey,TValue> : List<KeyValuePair<TKey,TValue>> {

		public const double MiddleMargin = 5.0d;
		public const double HeightMargin = 5.0d;

		public virtual TValue this [TKey key] {
			get {
				foreach(KeyValuePair<TKey,TValue> kvp in this) {
					if(kvp.Key.Equals(key)) {
						return kvp.Value;
					}
				}
				return default(TValue);
			}
			set {
				for(int i = 0x00; i < this.Count; i++) {
					if(this[i].Key.Equals(key)) {
						this[i] = new KeyValuePair<TKey,TValue>(key,value);
					}
				}
				throw new Exception("Couldn't find the proper key!");
			}
		}

		public KeyValueTable () {
		}

		public PointD MeasureSize (Context ctx, out double w1) {
			w1 = 0.0d;
			double w2 = 0.0d, h = 0.0d, ht = 0.0d;
			TextExtents te;
			foreach(KeyValuePair<TKey,TValue> kvp in this) {
				te = ctx.TextExtents(kvp.Key.ToString());
				w1 = Math.Max(w1,te.XAdvance);
				ht = te.Height;
				te = ctx.TextExtents(kvp.Value.ToString());
				w2 = Math.Max(w2,te.XAdvance);
				h += Math.Max(ht,te.Height);
			}
			w1 += MiddleMargin;
			return new PointD(w1+w2,h+2.0d*HeightMargin);
		}
		public PointD MeasureSize (Context ctx) {
			double w1;
			return MeasureSize(ctx,out w1);
		}
		public void Add (TKey key, TValue val) {
			this.Add(new KeyValuePair<TKey, TValue>(key,val));
		}
		public void Paint (Context ctx) {
			double w1;
			MeasureSize(ctx,out w1);
			TextExtents te;
			double h;
			ctx.Save();
			ctx.Translate(0.0d,HeightMargin);
			foreach(KeyValuePair<TKey,TValue> kvp in this) {
				te = ctx.TextExtents(kvp.Key.ToString());
				h = te.Height;
				te = ctx.TextExtents(kvp.Value.ToString());
				h = Math.Max(h,te.Height);
				ctx.Translate(0.0d,h);
				ctx.MoveTo(0.0d,0.0d);
				ctx.ShowText(kvp.Key.ToString());
				ctx.MoveTo(w1,0.0d);
				ctx.ShowText(kvp.Value.ToString());
			}
			ctx.Restore();
		}

	}
}

