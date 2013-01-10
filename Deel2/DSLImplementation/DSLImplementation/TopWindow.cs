using System;
using System.Reflection;
using DSLImplementation.UserInterface;
using DSLImplementation.Tiling;
using Gtk;
using Cairo;

namespace DSLImplementation
{
	public partial class TopWindow : Gtk.Window
	{

		private ListStore piecesStore;
		private ScrolledWindow sw;
		private SketchPad sketchpad;
		private IconView piecesView;

		public TopWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.initialize();
		}

		void initialize () {
			this.piecesStore = new ListStore(typeof(string),typeof(ConstructorInfo),typeof(Gdk.Pixbuf));
			this.piecesView = new IconView();
			this.piecesView.Model = this.piecesStore;
			this.piecesView.TextColumn = 0x00;
			this.piecesView.PixbufColumn = 0x02;
			this.piecesView.SelectionChanged += pieces_selection_changed;
			this.sketchpad = new SketchPad();
			this.sketchpad.RootPiece = new RunPiece();
			this.sketchpad.Tool = SketchPadTool.CreateNew;
			this.invokePieces(Assembly.GetExecutingAssembly());
			ScrolledWindow sw = new ScrolledWindow();
			ScrolledWindow sw2 = new ScrolledWindow();
			sw.Add(this.piecesView);
			sw.SetPolicy(PolicyType.Never,PolicyType.Always);
			sw.SetSizeRequest(700,100);
			sw2.AddWithViewport(this.sketchpad);
			sw2.SetPolicy(PolicyType.Always,PolicyType.Always);
			sw2.SetSizeRequest(700,500);
			this.vbox1.PackStart(sw,false,false,0x00);
			this.vbox1.PackStart(sw2,true,true,0x00);
			this.ShowAll();
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
		private void tool_saveaspdf (object sender, EventArgs e) {
			using(FileChooserDialog fcd_pdf = new FileChooserDialog("PDF File",this,FileChooserAction.Save)) {
				FileFilter ff = new FileFilter();
				ff.AddPattern("*.pdf");
				ff.Name = "PDF file";
				fcd_pdf.AddFilter(ff);
				fcd_pdf.AddButton("OK",ResponseType.Ok);
				int result = fcd_pdf.Run();
				if(result == (int) ResponseType.Ok) {
					PointD siz = this.sketchpad.MeasureSize();
					using(PdfSurface pdfs = new PdfSurface(fcd_pdf.Filename,siz.X,siz.Y)) {
						using(Context ctx = new Context(pdfs)) {
							this.sketchpad.PaintContext(ctx,(int) Math.Ceiling(siz.X),(int) Math.Ceiling(siz.Y));
						}
					}
				}
				fcd_pdf.HideAll();
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

