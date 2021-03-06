using System;

namespace DSLImplementation.UserInterface {

	[PuzzlePiece("Add",TypeColors.Red)]
	public class AddPiece : PuzzlePieceBase {

		private string[] argumentNames = new string[0x00];
		private TypeColors[] arguments = new TypeColors[0x00];

		public override TypeColors TypeColors {
			get {
				return TypeColors.Red;
			}
		}
		public override string[] ArgumentNames {
			get {
				return argumentNames;
			}
		}
		public override TypeColors[] TypeColorArguments {
			get {
				return arguments;
			}
		}
		public override int NumberOfOptionalArguments {
			get {
				return Math.Max(0x00,this.NumberOfArguments-0x01);
			}
		}
		public override bool Complete {
			get {
				return false;
			}
		}

		public AddPiece () {
			this.updateArguments(0x01);
		}

		private void updateArguments (int newn)
		{
			int n = this.NumberOfArguments;
			this.arguments = new TypeColors[newn];
			this.argumentNames = new string[newn];
			this.arguments[0x00] = TypeColors.All&~TypeColors.Red&~TypeColors.White;
			for (int i = 0x01; i < newn; i++) {
				this.arguments [i] = TypeColors.All;
			}
			this.argumentNames [0x00] = string.Format ("Item");
			for (int i = 0x01; i <= n; i++) {
				this.argumentNames [i] = string.Format ("Additional parameter", i);
			}
			this.SetArgumentSize ();
		}
		protected override void PerformChildrenChanged (object s, EventArgs e) {
			if (this [this.NumberOfArguments - 0x01] != null) {
				updateArguments (this.NumberOfArguments+0x01);
			}
			base.PerformChildrenChanged (s, e);
		}

	}
}

