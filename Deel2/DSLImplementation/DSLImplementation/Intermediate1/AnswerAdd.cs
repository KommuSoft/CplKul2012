using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode
{
	public class AnswerAdd : IAnswer
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
				yield return new SucceedFailPiece ("Failed", this.message);
			} else {
				yield return new SucceedFailPiece ();
			}
		}
	}
}

