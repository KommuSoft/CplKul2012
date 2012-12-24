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

namespace DSLImplementation {

	public class MainWindow : Window {

		private SketchPad sketchpad;
		private VBox vbox;
		private HBox hbox;
		private ListStore nodeStore = new ListStore(typeof(string),typeof(Gdk.Pixbuf),typeof(string),typeof(ConstructorInfo));
		private IconView nodeView;
		private ListStore edgeStore = new ListStore(typeof(string),typeof(Gdk.Pixbuf),typeof(string),typeof(ConstructorInfo));
		private IconView edgeView;

		public MainWindow () : base(WindowType.Toplevel) {
			this.SetSizeRequest(800, 600);
			this.Title = "Comparative Programming Languages - Domain Specific Language Assignment";
			this.vbox = new VBox(false,0x00);
			this.hbox = new HBox(false,0x00);
			this.invokeNodes(Assembly.GetExecutingAssembly());
			this.invokeEdges(Assembly.GetExecutingAssembly());
			this.nodeView = new IconView(this.nodeStore);
			this.nodeView.TextColumn = 0x00;
			this.nodeView.PixbufColumn = 0x01;
			this.nodeView.TooltipColumn = 0x02;
			this.nodeView.SelectionChanged += handleNodeSelectionChanged;
			this.edgeView = new IconView(this.edgeStore);
			this.edgeView.TextColumn = 0x00;
			this.edgeView.PixbufColumn = 0x01;
			this.edgeView.TooltipColumn = 0x02;
			this.edgeView.SelectionChanged += handleEdgeSelectionChanged;
			this.hbox.PackEnd(this.edgeView,true,true,0x00);
			this.hbox.PackEnd(this.nodeView,true,true,0x00);
			this.sketchpad = new SketchPad();
			this.vbox.PackEnd(this.sketchpad,true,true,0x00);
			this.vbox.PackEnd(this.hbox,false,false,0x00);
			this.Add(vbox);
			this.ShowAll();
		}

		private void handleNodeSelectionChanged (object sender, EventArgs e)
		{
			TreePath[] tp = this.nodeView.SelectedItems;
			if(tp.Length > 0x00) {
				TreeIter ti;
				if(this.nodeStore.GetIter(out ti,tp[0x00])) {
					this.sketchpad.InjectionNode = (INode) ((ConstructorInfo) this.nodeStore.GetValue(ti,0x03)).Invoke(new object[0x00]);
				}
			}
		}
		private void handleEdgeSelectionChanged (object sender, EventArgs e)
		{
			TreePath[] tp = this.edgeView.SelectedItems;
			if(tp.Length > 0x00) {
				TreeIter ti;
				if(this.edgeStore.GetIter(out ti,tp[0x00])) {
					this.sketchpad.InjectionEdge = (IEdge) ((ConstructorInfo) this.edgeStore.GetValue(ti,0x03)).Invoke(new object[0x00]);
				}
			}
		}
		private void invokeNodes (Assembly assembly) {
			ConstructorInfo ci;
			foreach(Type t in assembly.GetTypes()) {
				if(typeof(INode).IsAssignableFrom(t) && !t.IsAbstract) {
					ci = t.GetConstructor(new Type[0x00]);
					if(ci != null) {
						foreach(NodeAttribute na in t.GetCustomAttributes(typeof(NodeAttribute),false)) {
							this.nodeStore.AppendValues(na.Name,na.Preview,na.ToolTip,ci);
						}
					}
				}
			}
		}

		private void invokeEdges (Assembly assembly) {
			ConstructorInfo ci;
			foreach(Type t in assembly.GetTypes()) {
				if(typeof(IEdge).IsAssignableFrom(t) && !t.IsAbstract) {
					ci = t.GetConstructor(new Type[0x00]);
					if(ci != null) {
						foreach(EdgeAttribute na in t.GetCustomAttributes(typeof(EdgeAttribute),false)) {
							this.edgeStore.AppendValues(na.Name,na.Preview,na.ToolTip,ci);
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

