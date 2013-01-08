using System;

namespace DSLImplementation.XmlRepresentation {

	public abstract class XmlRequestBase : IXmlRequest {

		public abstract IXmlAnswer execute ();

	}
}

