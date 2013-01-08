using System;

namespace DSLImplementation.XmlRepresentation {

	public abstract class XmlRequestBase : IXmlRequest {

		abstract IXmlAnswer execute ();

	}
}

