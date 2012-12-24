using System;
using Cairo;

namespace DSLImplementation {

	[Node("Seat","seat.png","A seat")]
	public class SeatNode : RectangularImageNodeBase {

		protected override string DefaultImageName {
			get {
				return "seat.png";
			}
		}

		public SeatNode () {}
		public SeatNode (PointD location) : base(location) {}
		public SeatNode (PointD location, PointD size) : base(location,size) {}

		public override IPaintPrimitive Clone () {
			return new SeatNode(this.Location,this.Size);
		}

	}
}

