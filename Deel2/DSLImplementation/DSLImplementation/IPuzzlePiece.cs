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
		IPuzzlePiece PieceParent {
			get;
			set;
		}
		bool Complete {
			get;
		}
		event EventHandler BoundsChanged;

		void MatchesConstraintsChildren (int index, IPuzzlePiece piece);
		void MatchesConstraintsParent (IPuzzlePiece piece);
		bool IsOptional (int index);
		void Paint (Context ctx);
		PointD ChildLocation (Context ctx, int index);
		PointD InnerLocation (Context ctx);
		PointD OuterLocation (Context ctx);
		PointD MeasureSize (Context ctx);
		IPuzzlePiece GetPuzzleGap (Context ctx, PointD point, out int index);
		IPuzzlePiece GetPuzzlePiece (Context ctx, PointD point);

	}
}

