using System;

namespace DSLImplementation
{
	public partial class TopWindow : Gtk.Window
	{
		public TopWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

