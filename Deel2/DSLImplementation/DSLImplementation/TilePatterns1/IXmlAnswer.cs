using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode {

	public interface IXmlAnswer {

		IEnumerable<IPuzzlePiece> ToPuzzlePieces ();

	}
}

