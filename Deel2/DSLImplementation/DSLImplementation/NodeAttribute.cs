using System;
using Gdk;

namespace DSLImplementation {

	public class NodeAttribute : PaintPrimitiveAttribute {

		public NodeAttribute (string name, string previewImage) : this(name,previewImage,string.Empty) {}
		public NodeAttribute (string name, string previewImage, string tooltip) : base(name,previewImage,tooltip) {}

	}
}

