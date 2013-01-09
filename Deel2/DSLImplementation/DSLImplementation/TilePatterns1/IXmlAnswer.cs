using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.XmlRepresentation {

	public interface IXmlAnswer {

		IEnumerable<IPuzzlePiece> ToPuzzlePieces ();

	}
}

