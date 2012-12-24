using System;
using Gdk;

namespace DSLImplementation {

	[AttributeUsage(AttributeTargets.Class)]
	public abstract class PaintPrimitiveAttribute : Attribute {

		private readonly string name;
		private readonly string previewImage;
		private readonly string tooltip;
		private Pixbuf pb;

		public string Name {
			get {
				return this.name;
			}
		}
		public string PreviewName {
			get {
				return this.previewImage;
			}
		}
		public string ToolTip {
			get {
				return this.tooltip;
			}
		}
		public Pixbuf Preview {
			get {
				if(pb == null) {
					pb = ImageLoader.LoadPixbuf(this.PreviewName);
					pb = pb.ScaleSimple(32,32,InterpType.Bilinear);
				}
				return pb;
			}
		}

		protected PaintPrimitiveAttribute (string name, string previewImage) : this(name,previewImage,string.Empty) {
		}
		protected PaintPrimitiveAttribute (string name, string previewImage, string tooltip) {
			this.name = name;
			this.previewImage = previewImage;
			this.tooltip = tooltip;
		}

	}
}

