using System;
using Cairo;
using System.Collections.Generic;

namespace DSLImplementation {

	public interface IPainPrimitive {

		double GetScore (List<PointD> point, out IPainPrimitive primitive);
		void Paint (Context ctx);

	}
}

