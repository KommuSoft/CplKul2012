using System;
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
		public Tree (T data, params T[] subtrees) : this(data,(IEnumerable<T>) subtrees) {
		}
		public Tree (T data, IEnumerable<ITree<T>> subtrees) {
			this.data = data;
			this.subtrees = new List<ITree<T>>(subtrees);
		}
		public Tree (T data, IEnumerable<T> subtrees) {
			this.data = data;
			this.subtrees = new List<ITree<T>>();
			foreach(T subtree in subtrees) {
				this.subtrees.Add(new Tree<T>(subtree));
			}
		}

		public static bool ConjunctiveTreeSwapMatchPredicate<Q> (ITree<T> tree, int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate, out ITree<Q> swappedTree) {
			if(predicate(tree.Data,index,othertree.Data)) {
				int nt = tree.NumberOfChildren;
				int no = othertree.NumberOfChildren;
				ITree<Q>[] used = new ITree<Q>[no];
				ITree<Q>[] swap = new ITree<Q>[nt];
				ITree<Q> tmp;
				bool found;
				for(int i = 0x00; i < nt; i++) {
					found = false;
					for(int j = 0x00; j < no; j++) {
						if(othertree[j] != null && used[j] == null && ConjunctiveTreeSwapMatchPredicate(tree[i],i,othertree[j],predicate,out tmp)) {
							used[j] = tmp;
							swap[i] = tmp;
							found = true;
							break;
						}
					}
					if(found == false) {
						swappedTree = null;
						return false;
					}
				}
				swappedTree = new Tree<Q>(othertree.Data,swap);
				return true;
			}
			else {
				swappedTree = null;
				return false;
			}
		}
		public static bool ConjunctiveTreeNonSwapMatchPredicate<Q> (ITree<T> tree,int index, ITree<Q> othertree, TreeMatchingPredicate<T,Q> predicate) {
			if(predicate(tree.Data,index,othertree.Data)) {
				int nt = tree.NumberOfChildren;
				for(int i = 0x00; i < nt; i++) {
					if(othertree[i] == null || !ConjunctiveTreeNonSwapMatchPredicate(tree[i],i,othertree[i],predicate)) {
						return false;
					}
				}
				return true;
			}
			else {
				return false;
			}
		}

	}
}

