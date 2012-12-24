using System;
using Cairo;

namespace DSLImplementation {

	[Node("Country","country.png","A country")]
	public class CountryNode : RectangularImageNodeBase {

		protected override string DefaultImageName {
			get {
				return "country.png";
			}
		}

		public CountryNode () {}
		public CountryNode (PointD location) : base(location) {}
		public CountryNode (PointD location, PointD size) : base(location,size) {}

		public override IPaintPrimitive Clone () {
			return new CountryNode(this.Location,this.Size);
		}

	}
}

