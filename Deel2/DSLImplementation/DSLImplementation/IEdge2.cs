using System;

namespace DSLImplementation {

	public interface IEdge2 : IEdge {

		INode NodeFrom {
			get;
		}
		INode NodeTo {
			get;
		}

	}
}

