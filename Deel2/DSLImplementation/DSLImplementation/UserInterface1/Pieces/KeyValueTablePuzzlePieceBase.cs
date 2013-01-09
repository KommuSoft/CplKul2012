using System;
using System.Collections.Generic;
using Cairo;
using DSLImplementation.Tiling;

namespace DSLImplementation.UserInterface {

	public abstract class KeyValueTablePuzzlePieceBase : PuzzlePieceBase, IKeyValueTablePuzzlePiece<string,object> {

		private readonly ParsableKeyValueTable<string,object> table = new ParsableKeyValueTable<string,object>();
		private PointD size = new PointD(-0x01,-0x01);

		public ParsableKeyValueTable<string,object> Table {
			get {
				return this.table;
			}
		}

		public KeyValueTablePuzzlePieceBase () {
		}

		public override PointD MeasureSize (Context ctx) {
			if(size.X < 0x00) {
				PointD siza = base.MeasureSize(ctx);
				PointD sizb = this.table.MeasureSize(ctx);
				this.size = new PointD(siza.X+sizb.X,Math.Max(siza.Y,sizb.Y));
			}
			return size;
		}
		protected override void OnBoundsChanged (EventArgs e)
		{
			this.size.X = -0x01;
		}
		public override void Paint (Context ctx) {
			MeasureSize(ctx);
			base.Paint (ctx);
			PointD mid = base.MeasureSize(ctx);
			ctx.Save();
			ctx.Translate(mid.X,0.0d);
			this.table.Paint(ctx);
			ctx.Restore();
		}

		public override bool MatchBind (TypeBind tb, Dictionary<string, object> binddictionary) {
			if(tb.Bindingtable != null && tb.Bindingtable.Count > 0x00) {
				foreach(KeyValuePair<string,string> entry in tb.Bindingtable) {
					try {
						Console.WriteLine("adding {0}",entry.Key);
						binddictionary.Add(entry.Value,this.Table[entry.Key]);
						Console.WriteLine("[added]");
					}
					catch (Exception e) {
						Console.WriteLine("Error");
					}
				}
			}
			return true;
		}

	}
}

