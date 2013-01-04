using System;
using System.Collections.Generic;
using Gtk;

namespace DSLImplementation.UserInterface
{
	public class KeyValueTableEditor<TKey,TVal> : Dialog
	{

		private readonly KeyValueTable<TKey,TVal> table;
		private TreeView iv;
		private ListStore ls;
		private Button okbut;
		private Button cnbut;

		public KeyValueTable<TKey,TVal> Table {
			get {
				return this.table;
			}
		}

		public KeyValueTableEditor (KeyValueTable<TKey,TVal> table) : base()
		{
			this.SetSizeRequest(250,300);
			this.table = table;
			this.iv = new TreeView();
			this.ls = new ListStore(typeof(string),typeof(string));
			CellRendererText crt = new CellRendererText();
			TreeViewColumn tvc_col = new TreeViewColumn("Key",crt);
			tvc_col.AddAttribute(crt,"text",0x00);
			TreeViewColumn tvc_val = new TreeViewColumn("Value",crt);
			tvc_val.AddAttribute(crt,"text",0x01);
			this.iv.AppendColumn(tvc_col);
			this.iv.AppendColumn(tvc_val);
			this.invokeData();
			this.iv.Model = ls;
			this.cnbut = new Button("gtk-cancel");
			this.cnbut.CanDefault = true;
			this.cnbut.CanFocus = true;
			this.cnbut.Name = "buttonCancel";
			this.cnbut.UseStock = true;
			this.cnbut.UseUnderline = true;
			this.AddActionWidget (this.cnbut,ResponseType.Cancel);
			this.okbut = new Button("gtk-ok");
			this.okbut.CanDefault = true;
			this.okbut.CanFocus = true;
			this.okbut.Name = "buttonOk";
			this.okbut.UseStock = true;
			this.okbut.UseUnderline = true;
			this.AddActionWidget (this.okbut,ResponseType.Ok);
			this.VBox.PackEnd(this.iv,true,true,0x00);
			this.ShowAll();
		}

		private void invokeData ()
		{
			foreach(KeyValuePair<TKey,TVal> kvp in this.table) {
				Console.WriteLine("appended {0} {1}",kvp.Key,kvp.Value);
				ls.AppendValues(kvp.Key.ToString(),kvp.Value.ToString());
			}
		}

	}
}

