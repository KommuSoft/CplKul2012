using System;
using System.Collections.Generic;
using Gtk;

namespace DSLImplementation.UserInterface
{
	public class KeyValueTableEditor<TKey,TVal> : Dialog
	{

		private readonly ParsableKeyValueTable<TKey,TVal> table;
		private TreeView iv;
		private ListStore ls;
		private Button okbut;
		private Button cnbut;

		public ParsableKeyValueTable<TKey,TVal> Table {
			get {
				return this.table;
			}
		}

		public KeyValueTableEditor (ParsableKeyValueTable<TKey,TVal> table) : base()
		{
			this.SetSizeRequest(250,300);
			this.table = table;
			this.iv = new TreeView();
			this.ls = new ListStore(typeof(string),typeof(string));
			CellRendererText crt_key = new CellRendererText();
			CellRendererText crt_val = new CellRendererText();
			TreeViewColumn tvc_col = new TreeViewColumn("Key",crt_key);
			tvc_col.AddAttribute(crt_key,"text",0x00);
			TreeViewColumn tvc_val = new TreeViewColumn("Value",crt_val);
			tvc_val.AddAttribute(crt_val,"text",0x01);
			crt_val.Editable = true;
			crt_val.Edited += HandleEdited;
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

		void HandleEdited (object o, EditedArgs args)
		{
			TreeIter ti;
			this.ls.GetIter (out ti, new TreePath (args.Path));
			string str_key = (string)this.ls.GetValue (ti, 0x00);
			try {
				this.table.CheckCanParse (str_key, args.NewText);
				this.ls.SetValue(ti,0x01,args.NewText);
			} catch (Exception e) {
				ExtensionMethods.ShowException(e);
			}
		}

		private void invokeData ()
		{
			foreach(KeyValuePair<TKey,TVal> kvp in this.table) {
				ls.AppendValues(kvp.Key.ToString(),kvp.Value.ToString());
			}
		}

		private IEnumerable<KeyValuePair<string,string>> getTuples ()
		{
			TreeIter ti;
			if (this.ls.GetIterFirst (out ti)) {
				do {
					yield return new KeyValuePair<string, string>(
						(string) this.ls.GetValue(ti,0x00),
						(string) this.ls.GetValue(ti,0x01)
					);
				}
				while(this.ls.IterNext(ref ti));
			}
		}

		public static void RunDialog<TK,TV> (ParsableKeyValueTable<TK,TV> pvkp) {
			using(KeyValueTableEditor<TK,TV> editor = new KeyValueTableEditor<TK, TV>(pvkp)) {
				int res = editor.Run();
				editor.HideAll();
				switch(res) {
					case (int) ResponseType.Ok :
						pvkp.SetKeyValues(editor.getTuples());
						break;
				}
			}
		}

	}
}

