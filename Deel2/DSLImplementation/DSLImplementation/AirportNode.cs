using System;
using Cairo;

namespace DSLImplementation
{

	[Node("Airport","airport.png","An airport.")]
	public class AirportNode : RectangularImageNodeBase {

		protected override string DefaultImageName {
			get {
				return "airport.png";
			}
		}

		public AirportNode () {}
		public AirportNode (PointD center, PointD size) : base(center,size) {}
		public AirportNode (PointD center) : base(center) {}

		public override IPaintPrimitive Clone () {
			return new AirportNode(this.Location,this.Size);
		}

	}
}

