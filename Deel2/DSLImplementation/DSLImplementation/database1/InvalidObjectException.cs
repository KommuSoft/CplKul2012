using System;

namespace DSLImplementation.Database
{
	public class InvalidObjectException : Exception
	{
		public InvalidObjectException (string text) : base(text) {}
	}
}

