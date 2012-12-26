using System;
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
		TypeColors TypeColors {
			get;
		}
		string Name {
			get;
		}
		event EventHandler BoundsChanged;

		bool MatchesConstraints (int index, IPuzzlePiece piece);
		bool IsOptional (int index);
		void Paint (Context ctx);
		PointD MeasureSize (Context ctx);
		IPuzzlePiece GetPuzzleGap (Context ctx, PointD point, out int index);

	}
}

