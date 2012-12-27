//
//  MainWindow.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2012 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Reflection;
using Gtk;

namespace DSLImplementation.UserInterface {

	public class MainWindow : Window {

		private SketchPad sketchpad;
		private IconView piecesView;
		private ListStore piecesStore;
		private VBox vbox;
		private MenuBar menubar;
		private Toolbar toolbar;

		public MainWindow () : base(WindowType.Toplevel) {
			this.SetSizeRequest(800, 600);
			this.Title = "Comparative Programming Languages - Domain Specific Language Assignment";
			this.vbox = new VBox(false,0x00);
			this.sketchpad = new SketchPad();
			this.sketchpad.RootPiece = new RunPiece();
			this.piecesStore = new ListStore(typeof(string),typeof(ConstructorInfo),typeof(Gdk.Pixbuf));
			this.invokePieces(Assembly.GetExecutingAssembly());
			this.piecesView = new IconView(this.piecesStore);
			this.piecesView.TextColumn = 0x00;
			this.piecesView.PixbufColumn = 0x02;
			this.piecesView.SelectionChanged += HandleSelectionChanged;
			#region Menu
			this.menubar = new MenuBar();
			MenuItem		mi_tool = new MenuItem("Tools");
			Menu			mn_tool = new Menu();
			RadioMenuItem	mi_tool_crsb = new RadioMenuItem("Insert subpieces");
			mn_tool.Append(mi_tool_crsb);
			RadioMenuItem	mi_tool_link = new RadioMenuItem(mi_tool_crsb,"Create link piece");
			mn_tool.Append(mi_tool_link);
			RadioMenuItem	mi_tool_edit = new RadioMenuItem(mi_tool_crsb,"Edit information");
			mn_tool.Append(mi_tool_edit);
			mn_tool.Append(new SeparatorMenuItem());
			MenuItem		mi_tool_exec = new MenuItem("Execute Query");
			mn_tool.Append(mi_tool_exec);
			mi_tool.Submenu = mn_tool;
			this.menubar.Append(mi_tool);
			#endregion
			#region Toolbar
			this.toolbar = new Toolbar();
			this.toolbar.Add(mi_tool_crsb);
			#endregion
			this.vbox.PackEnd(this.sketchpad,true,true,0x00);
			this.vbox.PackEnd(this.piecesView,false,false,0x00);
			this.vbox.PackEnd(this.toolbar,false,false,0x00);
			this.vbox.PackEnd(this.menubar,false,false,0x00);
			this.Add(vbox);
			this.ShowAll();
		}

		void HandleSelectionChanged (object sender, EventArgs e)
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

		private void invokePieces (Assembly assembly) {
			foreach(Type t in assembly.GetTypes()) {
				if(!t.IsAbstract && typeof(IPuzzlePiece).IsAssignableFrom(t)) {
					ConstructorInfo ci = t.GetConstructor(new Type[0x00]);
					if(ci != null) {
						foreach(PuzzlePieceAttribute ppa in t.GetCustomAttributes(typeof(PuzzlePieceAttribute),false)) {
							piecesStore.AppendValues(ppa.PieceName,ci,ppa.Icon);
						}
					}
				}
			}
		}

		public static int Main (string[] args) {
			Application.Init();
			Gdk.Threads.Init();
			Gdk.Threads.Enter();
			using(MainWindow mw = new MainWindow()) {
				Application.Run();
			}
			return 0;
		}

	}
}

