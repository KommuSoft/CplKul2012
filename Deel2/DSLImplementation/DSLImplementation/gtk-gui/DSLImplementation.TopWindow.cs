
// This file has been generated by the GUI designer. Do not modify.
namespace DSLImplementation
{
	public partial class TopWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action ToolsAction;
		private global::Gtk.RadioAction menu_insertSubpiece;
		private global::Gtk.RadioAction menu_insert_linkpiece;
		private global::Gtk.RadioAction menu_edit_information;
		private global::Gtk.Action Action;
		private global::Gtk.Action propertiesAction;
		private global::Gtk.RadioAction tool_insertSubpiece;
		private global::Gtk.RadioAction tool_insert_linkpiece;
		private global::Gtk.RadioAction tool_edit_information;
		private global::Gtk.Action tool_execute_query;
		private global::Gtk.ToggleAction menu_autorun;
		private global::Gtk.ToggleAction tool_autorun;
		private global::Gtk.VBox vbox1;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.Toolbar toolbar1;
		private global::Gtk.IconView piecesView;
		private global::DSLImplementation.UserInterface.SketchPad sketchpad;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DSLImplementation.TopWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.ToolsAction = new global::Gtk.Action ("ToolsAction", global::Mono.Unix.Catalog.GetString ("Tools"), null, null);
			this.ToolsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Tools");
			w1.Add (this.ToolsAction, null);
			this.menu_insertSubpiece = new global::Gtk.RadioAction ("menu_insertSubpiece", global::Mono.Unix.Catalog.GetString ("Insert subpiece"), global::Mono.Unix.Catalog.GetString ("Insert subpiece"), "gtk-select-color", 0);
			this.menu_insertSubpiece.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.menu_insertSubpiece.ShortLabel = global::Mono.Unix.Catalog.GetString ("Insert subpiece");
			w1.Add (this.menu_insertSubpiece, null);
			this.menu_insert_linkpiece = new global::Gtk.RadioAction ("menu_insert_linkpiece", global::Mono.Unix.Catalog.GetString ("Insert linkpiece"), global::Mono.Unix.Catalog.GetString ("Insert linkpiece"), "gtk-convert", 0);
			this.menu_insert_linkpiece.Group = this.menu_insertSubpiece.Group;
			this.menu_insert_linkpiece.ShortLabel = global::Mono.Unix.Catalog.GetString ("Insert linkpiece");
			w1.Add (this.menu_insert_linkpiece, null);
			this.menu_edit_information = new global::Gtk.RadioAction ("menu_edit_information", global::Mono.Unix.Catalog.GetString ("Edit information"), global::Mono.Unix.Catalog.GetString ("Edit information"), "gtk-index", 0);
			this.menu_edit_information.Group = this.menu_insert_linkpiece.Group;
			this.menu_edit_information.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit information");
			w1.Add (this.menu_edit_information, null);
			this.Action = new global::Gtk.Action ("Action", global::Mono.Unix.Catalog.GetString ("--"), null, null);
			this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString ("--");
			w1.Add (this.Action, null);
			this.propertiesAction = new global::Gtk.Action ("propertiesAction", global::Mono.Unix.Catalog.GetString ("Execute query"), null, "gtk-properties");
			this.propertiesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute query");
			w1.Add (this.propertiesAction, null);
			this.tool_insertSubpiece = new global::Gtk.RadioAction ("tool_insertSubpiece", global::Mono.Unix.Catalog.GetString ("Insert subpiece"), global::Mono.Unix.Catalog.GetString ("Insert subpiece"), "gtk-select-color", 0);
			this.tool_insertSubpiece.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.tool_insertSubpiece.ShortLabel = global::Mono.Unix.Catalog.GetString ("Insert subpiece");
			w1.Add (this.tool_insertSubpiece, null);
			this.tool_insert_linkpiece = new global::Gtk.RadioAction ("tool_insert_linkpiece", global::Mono.Unix.Catalog.GetString ("Insert linkpiece"), global::Mono.Unix.Catalog.GetString ("Insert linkpiece"), "gtk-convert", 0);
			this.tool_insert_linkpiece.Group = this.tool_insertSubpiece.Group;
			this.tool_insert_linkpiece.ShortLabel = global::Mono.Unix.Catalog.GetString ("Insert linkpiece");
			w1.Add (this.tool_insert_linkpiece, null);
			this.tool_edit_information = new global::Gtk.RadioAction ("tool_edit_information", global::Mono.Unix.Catalog.GetString ("Edit information"), global::Mono.Unix.Catalog.GetString ("Edit information"), "gtk-index", 0);
			this.tool_edit_information.Group = this.tool_insert_linkpiece.Group;
			this.tool_edit_information.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit information");
			w1.Add (this.tool_edit_information, null);
			this.tool_execute_query = new global::Gtk.Action ("tool_execute_query", global::Mono.Unix.Catalog.GetString ("Execute Query"), global::Mono.Unix.Catalog.GetString ("Execute Query"), "gtk-execute");
			this.tool_execute_query.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute Query");
			w1.Add (this.tool_execute_query, null);
			this.menu_autorun = new global::Gtk.ToggleAction ("menu_autorun", global::Mono.Unix.Catalog.GetString ("Execute complete queries"), global::Mono.Unix.Catalog.GetString ("Execute complete queries"), "gtk-refresh");
			this.menu_autorun.Active = true;
			this.menu_autorun.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute complete queries");
			w1.Add (this.menu_autorun, null);
			this.tool_autorun = new global::Gtk.ToggleAction ("tool_autorun", global::Mono.Unix.Catalog.GetString ("Execute complete queries"), global::Mono.Unix.Catalog.GetString ("Execute complete queries"), "gtk-refresh");
			this.tool_autorun.Active = true;
			this.tool_autorun.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute complete queries");
			w1.Add (this.tool_autorun, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.WidthRequest = 800;
			this.HeightRequest = 600;
			this.Name = "DSLImplementation.TopWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Comparative Programming Languages - Domain Specific Language Assignment");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child DSLImplementation.TopWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='ToolsAction' action='ToolsAction'><menuitem name='menu_insertSubpiece' action='menu_insertSubpiece'/><menuitem name='menu_insert_linkpiece' action='menu_insert_linkpiece'/><menuitem name='menu_edit_information' action='menu_edit_information'/><separator/><menuitem name='menu_autorun' action='menu_autorun'/><menuitem name='propertiesAction' action='propertiesAction'/></menu></menubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vbox1.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='tool_insertSubpiece' action='tool_insertSubpiece'/><toolitem name='tool_insert_linkpiece' action='tool_insert_linkpiece'/><toolitem name='tool_edit_information' action='tool_edit_information'/><separator/><toolitem name='tool_autorun' action='tool_autorun'/><toolitem name='tool_execute_query' action='tool_execute_query'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox1.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.piecesView = new global::Gtk.IconView ();
			this.piecesView.CanFocus = true;
			this.piecesView.Name = "piecesView";
			this.vbox1.Add (this.piecesView);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.piecesView]));
			w4.Position = 2;
			w4.Expand = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.sketchpad = new global::DSLImplementation.UserInterface.SketchPad ();
			this.sketchpad.Name = "sketchpad";
			this.sketchpad.Autorun = false;
			this.vbox1.Add (this.sketchpad);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.sketchpad]));
			w5.Position = 3;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 600;
			this.Show ();
			this.menu_insertSubpiece.Activated += new global::System.EventHandler (this.menu_tool_changed);
			this.menu_insert_linkpiece.Activated += new global::System.EventHandler (this.menu_tool_changed);
			this.menu_edit_information.Activated += new global::System.EventHandler (this.menu_tool_changed);
			this.tool_insertSubpiece.Activated += new global::System.EventHandler (this.tool_selected);
			this.tool_insert_linkpiece.Activated += new global::System.EventHandler (this.tool_selected);
			this.tool_edit_information.Activated += new global::System.EventHandler (this.tool_selected);
			this.menu_autorun.Activated += new global::System.EventHandler (this.menu_autorun_changed);
			this.tool_autorun.Activated += new global::System.EventHandler (this.tool_autorun_changed);
			this.piecesView.SelectionChanged += new global::System.EventHandler (this.pieces_selection_changed);
		}
	}
}