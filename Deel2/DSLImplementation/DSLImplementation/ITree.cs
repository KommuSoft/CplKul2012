using System;

namespace DSLImplementation {

	public interface ITree<T> {

		T Data {
			get;
		}

		ITree<T> this [int index] {
			get;
		}
		int NumberOfChildren {
			get;
		}

	}
}

