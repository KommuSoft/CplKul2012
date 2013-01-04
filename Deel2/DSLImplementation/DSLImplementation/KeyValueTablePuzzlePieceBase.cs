using System;
using Cairo;

namespace DSLImplementation.UserInterface {

	public abstract class KeyValueTablePuzzlePieceBase<TKey,TValue> : PuzzlePieceBase, IKeyValueTablePuzzlePiece<TKey,TValue> {

		private readonly KeyValueTable<TKey,TValue> table = new KeyValueTable<TKey,TValue>();
		private PointD size = new PointD(-0x01,-0x01);

		public KeyValueTable<TKey,TValue> Table {
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
		public override void Paint (Context ctx) {
			MeasureSize(ctx);
			base.Paint (ctx);
			PointD mid = base.MeasureSize(ctx);
			ctx.Save();
			ctx.Translate(mid.X,0.0d);
			this.table.Paint(ctx);
			ctx.Restore();
		}

	}
}

