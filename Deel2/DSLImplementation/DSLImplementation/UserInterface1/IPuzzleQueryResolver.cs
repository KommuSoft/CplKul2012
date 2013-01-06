using System;

namespace DSLImplementation.UserInterface {

	public interface IPuzzleQueryResolver {

		IPuzzlePiece[] Resolve (IPuzzlePiece query);

	}

}