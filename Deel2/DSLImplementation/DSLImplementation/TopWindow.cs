using System;
using System.Reflection;
using DSLImplementation.UserInterface;
using Gtk;

namespace DSLImplementation
{
	public partial class TopWindow : Gtk.Window
	{

		private ListStore piecesStore;

		public TopWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.initialize();
		}

		void initialize ()
		{
			this.piecesStore = new ListStore(typeof(string),typeof(ConstructorInfo),typeof(Gdk.Pixbuf));
			this.piecesView.Model = this.piecesStore;
			this.piecesView.TextColumn = 0x00;
			this.piecesView.PixbufColumn = 0x02;
			this.sketchpad.RootPiece = new RunPiece();
			this.sketchpad.Tool = SketchPadTool.CreateNew;
			this.invokePieces(Assembly.GetExecutingAssembly());
		}

		private void invokePieces (Assembly assembly) {
			foreach(Type t in assembly.GetTypes()) {
				if(!t.IsAbstract && t.IsClass && typeof(IPuzzlePiece).IsAssignableFrom(t)) {
					ConstructorInfo ci = t.GetConstructor(new Type[0x00]);
					if(ci != null) {
						foreach(PuzzlePieceAttribute ppa in t.GetCustomAttributes(typeof(PuzzlePieceAttribute),false)) {
							piecesStore.AppendValues(ppa.PieceName,ci,ppa.Icon);
						}
					}
				}
			}
		}

		protected void pieces_selection_changed (object sender, EventArgs e)
		{
			TreePath[] tps = this.piecesView.SelectedItems;
			if (tps.Length <= 0x00) {
				this.sketchpad.InjectionPiece = null;
			} else {
				TreeIter ti;
				this.piecesStore.GetIter(out ti, tps[0x00]);
				this.sketchpad.InjectionPiece = (ConstructorInfo) this.piecesStore.GetValue(ti,0x01);
			}
		}

		public static int Main (string[] args) {
			Application.Init();
			Gdk.Threads.Init();
			Gdk.Threads.Enter();
			TilingAlgorithm.LoadAssembly(Assembly.GetExecutingAssembly());
			using(TopWindow mw = new TopWindow()) {
				Application.Run();
			}
			return 0;
		}

		protected void tool_selected (object sender, EventArgs e)
		{
			if (this.tool_insertSubpiece.Active && !this.menu_insertSubpiece.Active) {
				this.sketchpad.Tool = SketchPadTool.CreateNew;
				this.menu_insertSubpiece.Activate ();
			} else if (this.tool_insert_linkpiece.Active && !this.menu_insert_linkpiece.Active) {
				this.sketchpad.Tool = SketchPadTool.Link;
				this.menu_insert_linkpiece.Activate ();
			} else if(this.tool_edit_information.Active && !this.menu_edit_information.Active) {
				this.sketchpad.Tool = SketchPadTool.Modify;
				this.menu_edit_information.Activate ();
			} else if(this.tool_delete_piece.Active && !this.menu_delete_piece.Active) {
				this.sketchpad.Tool = SketchPadTool.Remove;
				this.menu_delete_piece.Activate ();
			}
		}
		protected void menu_tool_changed (object sender, EventArgs e) {
			if (this.menu_insertSubpiece.Active && !this.tool_insertSubpiece.Active) {
				this.sketchpad.Tool = SketchPadTool.CreateNew;
				this.tool_insertSubpiece.Activate ();
			} else if (this.menu_insert_linkpiece.Active && !this.tool_insert_linkpiece.Active) {
				this.sketchpad.Tool = SketchPadTool.Link;
				this.tool_insert_linkpiece.Activate ();
			} else if(this.menu_edit_information.Active && !this.tool_edit_information.Active) {
				this.sketchpad.Tool = SketchPadTool.Modify;
				this.tool_edit_information.Activate ();
			} else if(this.menu_delete_piece.Active && !this.tool_delete_piece.Active) {
				this.sketchpad.Tool = SketchPadTool.Remove;
				this.tool_delete_piece.Activate ();
			}
		}
		protected void menu_autorun_changed (object sender, EventArgs e)
		{
			if (this.menu_autorun.Active ^ this.tool_autorun.Active) {
				this.sketchpad.Autorun = this.menu_autorun.Active;
				this.tool_autorun.Active = this.menu_autorun.Active;
			}
		}
		protected void tool_autorun_changed (object sender, EventArgs e) {
			if (this.menu_autorun.Active ^ this.tool_autorun.Active) {
				this.sketchpad.Autorun = this.tool_autorun.Active;
				this.menu_autorun.Active = this.tool_autorun.Active;
			}
		}
		
		protected void tool_query_exec (object sender, EventArgs e) {
			this.sketchpad.ExecuteQuery();
		}

	}
}

