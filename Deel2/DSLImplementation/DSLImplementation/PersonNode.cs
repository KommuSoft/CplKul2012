using System;
using Cairo;

namespace DSLImplementation
{
	[Node("Person","person.png","")]
	public class PersonNode : RectangularImageTextNodeBase {

		protected override string DefaultImageName {
			get {
				return "person.png";
			}
		}
		protected override string DefaultText {
			get {
				return "Name";
			}
		}

		public PersonNode () {
		}
		public PersonNode (PointD location) : base(location) {
		}
		public PersonNode (PointD location, PointD size) : base(location,size) {
		}

		public override IPaintPrimitive Clone () {
			return new PersonNode(this.Location,this.Size);
		}

	}
}

