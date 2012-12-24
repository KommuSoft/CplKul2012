using System;
using System.Collections.Generic;

namespace DSLImplementation
{
	public class TreeNode<T> {

		private T data;
		private readonly List<TreeNode<T>> children = new List<TreeNode<T>>();
		private TreeNode<T> parent;

		public T Data {
			get {
				return this.data;
			}
			set {
				this.data = value;
			}
		}
		public TreeNode<T> Parent {
			get {
				return this.parent;
			}
			protected set {
				if(this.parent != value) {
					if(this.parent != null) {
						TreeNode<T> par = this.parent;
						this.parent = null;
						par.Remove(this);
					}
					this.parent = value;
				}
			}
		}

		public TreeNode (T data) {
			this.data = data;
		}
		public TreeNode (T data, IEnumerable<TreeNode<T>> children) : this(data) {
			foreach(TreeNode<T> child in children) {
				this.Add(child);
			}
		}

		private bool checkLoop (TreeNode<T> virtualParent) {
			while(virtualParent != null && virtualParent != this) {
				virtualParent = virtualParent.Parent;
			}
			return (virtualParent != this);
		}

		public bool Add (TreeNode<T> child)
		{
			if (child.parent != null && !child.checkLoop (this)) {
				child.Parent = this;
				this.children.Add (child);
				return true;
			} else {
				return false;
			}
		}
		public void Remove (TreeNode<T> child) {
			child.Parent = null;
			this.children.Remove(child);
		}

		public IEnumerable<T> DepthFirst () {
			yield return this.data;
			foreach(TreeNode<T> child in this.children) {
				foreach(T data in child.DepthFirst()) {
					yield return data;
				}
			}
		}
		public IEnumerable<TreeNode<T>> Children () {
			foreach(TreeNode<T> child in this.children) {
				yield return child;
			}
		}

	}
}