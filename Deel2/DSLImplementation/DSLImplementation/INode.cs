using System;
using System.Collections.Generic;
using Cairo;

namespace DSLImplementation
{
	public interface INode : IPaintPrimitive {

		PointD Location {
			get;
			set;
		}
		event EventHandler BoundsChanged;

		PointD GetLocationByAngle (double theta);
		PointD GetLocationByOtherPoint (PointD other);
		void PaintContour (Context ctx);
		bool AcceptEdge (IEdge edge, ICollection<INode> othernodes, ref string message);

	}
}