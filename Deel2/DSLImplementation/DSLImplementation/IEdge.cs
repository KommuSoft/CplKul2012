using System;

namespace DSLImplementation {

	public interface IEdge : IPaintPrimitive {

		void setEdgeNode (int index, INode node);

	}
}

