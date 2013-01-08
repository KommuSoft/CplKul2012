using System;

namespace DSLImplementation.XmlRepresentation {

	public class XmlRequestBase : IXmlRequest {

		#region IXmlRequest implementation
		public IXmlAnswer PerformAction () {
			return null;//TODO: send query and receive the result!!
		}
		#endregion

	}
}

