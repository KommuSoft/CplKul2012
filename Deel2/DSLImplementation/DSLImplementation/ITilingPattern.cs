using System;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	public interface ITilingPattern {

		bool Match (IPuzzlePiece root);
		IXmlRequest ToTransferCode (IPuzzlePiece root);

	}

}