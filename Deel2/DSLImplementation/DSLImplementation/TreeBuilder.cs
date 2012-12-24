using System;

namespace DSLImplementation {

	public class TreeBuilder<T> {

		private TreeNode<T> root;
		private TreeNode<T> current;

		public TreeNode<T> Result {
			get {
				return this.root;
			}
		}

		public TreeBuilder () {
		}

		public void Add (T data)
		{
			if (this.current != null) {
				this.current.Add(new TreeNode<T>(data));
			} else {
				this.current = this.root = new TreeNode<T>(data);
			}
		}
		public void PushAdd (T data) {
			if (this.current != null) {
				TreeNode<T> newcur = new TreeNode<T>(data);
				this.current.Add(newcur);
				this.current = newcur;
			} else {
				this.root = this.current = new TreeNode<T> (data);
			}
		}
		public void Pop () {
			this.current = current.Parent;
		}

	}
}

