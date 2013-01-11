using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode {

	public interface IAnswer {

		IEnumerable<IPuzzlePiece> ToPuzzlePieces ();

	}
}

