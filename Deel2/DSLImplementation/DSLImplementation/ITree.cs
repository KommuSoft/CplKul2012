using System;

namespace DSLImplementation {

	public interface ITree<T> {

		T Data {
			get;
		}

		ITree<T> ChildAt (int index);
		int NumberOfChildren {
			get;
		}

	}
}

