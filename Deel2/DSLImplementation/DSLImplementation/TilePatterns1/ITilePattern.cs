using System;
using DSLImplementation.XmlRepresentation;

namespace DSLImplementation.UserInterface {

	public interface ITilePattern {

		bool Match (IPuzzlePiece root);
		IXmlRequest ToTransferCode (IPuzzlePiece root);

	}

}