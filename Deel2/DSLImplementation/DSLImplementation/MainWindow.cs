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
		private VBox vbox;

		public MainWindow () : base(WindowType.Toplevel) {
			this.SetSizeRequest(800, 600);
			this.Title = "Comparative Programming Languages - Domain Specific Language Assignment";
			this.vbox = new VBox(false,0x00);
			this.sketchpad = new SketchPad();
			this.sketchpad.RootPiece = new RunPiece(new BookingPiece());
			this.vbox.PackEnd(this.sketchpad,true,true,0x00);
			this.Add(vbox);
			this.ShowAll();
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

