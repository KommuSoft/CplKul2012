using System;
using System.Collections.Generic;
using Cairo;
using DSLImplementation.Tiling;

namespace DSLImplementation.UserInterface {

	public interface IPuzzlePiece : ITree<IPuzzlePiece> {

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
		bool CanExecute {
			get;
		}
		event EventHandler BoundsChanged;
		event EventHandler Killed;

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
		void InvalidateSizeCache ();
		bool Match (TypeBind tm);
		bool MatchBind (TypeBind tm, Dictionary<string,object> bindDictionary);
		void Kill ();

	}
}

