using System;
using System.Collections.Generic;
using Cairo;

namespace DSLImplementation.UserInterface {

	public interface IPuzzlePiece {

		int NumberOfArguments {
			get;
		}
		bool IsLeaf {
			get;
		}
		IPuzzlePiece this [int indexer] {
			get;
			set;
		}
		int Index {
			get;
			set;
		}
		TypeColors TypeColors {
			get;
		}
		string Name {
			get;
		}
		IPuzzlePiece Parent {
			get;
			set;
		}
		bool Complete {
			get;
		}
		event EventHandler BoundsChanged;

		bool MatchesConstraints (int index, IPuzzlePiece piece);
		bool IsOptional (int index);
		void Paint (Context ctx);
		PointD MeasureSize (Context ctx);
		IPuzzlePiece GetPuzzleGap (Context ctx, PointD point, out int index);
		IEnumerable<IPuzzlePiece> DepthFirstTraverse ();

	}
}

