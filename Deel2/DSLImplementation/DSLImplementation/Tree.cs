using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation {

	public delegate bool TreeMatchingPredicate<T,Q> (T t, int index, Q q);

	public class Tree<T> : ITree<T> {

		private readonly T data;
		private readonly List<ITree<T>> subtrees;

		public T Data {
			get {
				return this.data;
			}
		}
		public ITree<T> this [int index] {
			get {
				return this.subtrees[index];
			}
		}
		public int NumberOfChildren {
			get {
				return this.subtrees.Count;
			}
		}

		public Tree (T data) : this(data,new ITree<T>[0x00]) {
		}
		public Tree (T data, params ITree<T>[] subtrees) : this(data,(IEnumerable<ITree<T>>) subtrees) {
		}
		public Tree (T data, params T[] items) : this(data,(IEnumerable<T>) items) {
		}
		public Tree (T data, IEnumerable<ITree<T>> subtrees) {
			this.data = data;
			this.subtrees = new List<ITree<T>>(subtrees);
		}
		public Tree (T data, IEnumerable<T> items) {
			this.data = data;
			this.subtrees = new List<ITree<T>>();
			foreach(T item in items) {
				this.subtrees.Add(new Tree<T>(item));
			}
		}
		public ITree<T> ChildAt (int index) {
			return this[index];
		}
		public static bool ConjunctiveTreeSwapMatchPredicate<Q> (ITree<T> tree, int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate, out ITree<Q> swappedTree) {
			swappedTree = null;
			Console.WriteLine("matching {0};{1};{2}={3}",tree.Data,index,othertree.Data,predicate(tree.Data,index,othertree.Data));
			if(predicate(tree.Data,index,othertree.Data)) {
				int no = othertree.NumberOfChildren;
				int nt = tree.NumberOfChildren;
				ITree<Q>[] used = new ITree<Q>[no];
				ITree<Q>[] swap = new ITree<Q>[nt];
				ITree<Q> tmp;
				bool found;
				for(int i = 0x00; i < nt; i++) {
					found = false;
					for(int j = 0x00; j < no; j++) {
						if(othertree.ChildAt(j) != null && used[j] == null && ConjunctiveTreeSwapMatchPredicate(tree.ChildAt(i),j,othertree.ChildAt(j),predicate,out tmp)) {
							used[j] = tmp;
							swap[i] = tmp;
							found = true;
							break;
						}
					}
					if(found == false) {
						return false;
					}
				}
				swappedTree = new Tree<Q>(othertree.Data,swap);
				return true;
			}
			else {
				return false;
			}
		}
		public static bool ConjunctiveTreeNonSwapMatchPredicate<Q> (ITree<T> tree,int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate) {
			if(predicate(tree.Data,index,othertree.Data)) {
				int nt = tree.NumberOfChildren;
				for(int i = 0x00; i < nt; i++) {
					if(othertree.ChildAt(i) == null || !ConjunctiveTreeNonSwapMatchPredicate(tree.ChildAt(i),i,othertree.ChildAt(i),predicate)) {
						return false;
					}
				}
				return true;
			}
			else {
				return false;
			}
		}
		public override string ToString ()
		{
			if (this.subtrees != null && this.subtrees.Count > 0x00) {
				StringBuilder sb = new StringBuilder();
				foreach(Tree<T> tt in this.subtrees) {
					if(tt != null) {
						sb.Append(tt.ToString());
					}
				}
				return string.Format ("{0}({1})", Data,sb.ToString());
			} else {
				return Data.ToString();
			}
		}

	}
}

