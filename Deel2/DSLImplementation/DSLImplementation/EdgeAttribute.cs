using System;

namespace DSLImplementation {

	public class EdgeAttribute : PaintPrimitiveAttribute {

		public EdgeAttribute (string name, string previewImage) : this(name,previewImage,string.Empty) {}
		public EdgeAttribute (string name, string previewImage, string tooltip) : base(name,previewImage,tooltip) {}

	}
}

