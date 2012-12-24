using System;
using Cairo;

namespace DSLImplementation {

	[Node("Time","time.png","")]
	public class TimeNode : RectangularImageTextNodeBase {

		protected override string DefaultImageName {
			get {
				return "time.png";
			}
		}
		protected override string DefaultText {
			get {
				return "00:00";
			}
		}

		public TimeNode () : base() {}
		public TimeNode (PointD location) : base(location) {}
		public TimeNode (PointD location, PointD size) : base(location,size) {}

		public override IPaintPrimitive Clone () {
			return new TimeNode(this.Location,this.Size);
		}

	}
}

