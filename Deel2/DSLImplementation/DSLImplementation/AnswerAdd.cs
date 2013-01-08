using System;
using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.XmlRepresentation
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

		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			yield return new SucceedFailPiece();//TODO: invoke arguments
		}
	}
}

