using System;
using Cairo;

namespace DSLImplementation {

	[Node("Flight","flight.png","An object that represents a flight: flights are performed by planes on a regular base from an airport to another airport at a certain time.")]
	public class FlightNode : RectangularImageTextNodeBase {

		protected override string DefaultImageName {
			get {
				return "flight.png";
			}
		}
		protected override string DefaultText {
			get {
				return "AAA";
			}
		}

		public FlightNode () : base() {}
		public FlightNode (PointD center, PointD size) : base(center,size) {
		}

		public override IPaintPrimitive Clone () {
			return new FlightNode(this.Location,this.Size);
		}

	}

}