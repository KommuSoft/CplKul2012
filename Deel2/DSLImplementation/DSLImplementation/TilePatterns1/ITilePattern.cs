using System;
using DSLImplementation.UserInterface;
using DSLImplementation.IntermediateCode;

namespace DSLImplementation.Tiling {

	public interface ITilePattern {

		bool Match (IPuzzlePiece root);
		IRequest ToTransferCode (IPuzzlePiece root);

	}

}