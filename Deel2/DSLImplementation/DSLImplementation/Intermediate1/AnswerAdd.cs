using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode
{
	public class AnswerAdd : IXmlAnswer
	{
		public bool succesful { get; set; }
		public string message { get; set; }

		public AnswerAdd ()
		{
			succesful = true;
			message = "The add was succesfully executed";
		}

		public AnswerAdd (string message)
		{
			succesful = false;
			this.message = message;
		}

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces ()
		{
			if (!this.succesful) {
				Console.Error.WriteLine ("ERROR {0}", this.message);
				Console.WriteLine ("ERROR {0}", this.message);
				yield return new SucceedFailPiece ("Failed");//TODO: invoke arguments
			} else {
				yield return new SucceedFailPiece ();
			}
		}
	}
}

