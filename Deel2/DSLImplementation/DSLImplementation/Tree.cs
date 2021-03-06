using System;
using System.Text;
using System.Collections.Generic;

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
			return this.subtrees[index];
		}
		public static bool ConjunctiveTreeSwapMatchPredicate<Q> (ITree<T> tree, int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate, out ITree<Q> swappedTree) {
			return ConjunctiveTreeSwapMatchPredicate<Q>(tree,index,othertree,predicate,x => false, out swappedTree);
		}
		public static bool ConjunctiveTreeSwapMatchPredicate<Q> (ITree<T> tree, int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate, Predicate<T> optional, out ITree<Q> swappedTree) {
			swappedTree = null;
			if(othertree == null) {
				return false;
			}
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
						if(othertree.ChildAt(j) != null && used[j] == null && ConjunctiveTreeSwapMatchPredicate(tree.ChildAt(i),j,othertree.ChildAt(j),predicate,optional,out tmp)) {
							used[j] = tmp;
							swap[i] = tmp;
							found = true;
							break;
						}
					}
					if(found == false && !optional(tree.ChildAt(i).Data)) {
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
		public static bool ConjunctiveTreeNonSwapMatchPredicate<Q> (ITree<T> tree, int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate) {
			return ConjunctiveTreeNonSwapMatchPredicate(tree,index,othertree,predicate,x=>false);
		}
		public static bool ConjunctiveTreeNonSwapMatchPredicate<Q> (ITree<T> tree,int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate, Predicate<T> optional) {
			if(othertree == null) {
				return false;
			}
			if(predicate(tree.Data,index,othertree.Data)) {
				int nt = tree.NumberOfChildren;
				for(int i = 0x00; i < nt; i++) {
					if((othertree.ChildAt(i) != null && !ConjunctiveTreeNonSwapMatchPredicate(tree.ChildAt(i),i,othertree.ChildAt(i),predicate,optional)) && !optional(tree.ChildAt(i).Data)) {
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
					else {
						sb.Append("NULL");
					}
				}
				return string.Format ("{0}({1})", Data,sb.ToString());
			} else {
				return Data.ToString();
			}
		}

	}
}

