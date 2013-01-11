using System;

namespace DSLImplementation.IntermediateCode {

	public abstract class RequestBase : IRequest {

		public abstract IAnswer execute ();

	}
}

