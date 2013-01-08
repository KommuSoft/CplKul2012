using System;
using System.Collections.Generic;

namespace DSLImplementation.Database
{
	public class FlightTemplate : DatabaseTable
	{
		public string code { get; set; }

		public override string tableName ()
		{
			return "flight_template";
		}

		public FlightTemplate (string code)
		{
			this.code = code;
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (code.Length != 3 && code.Length != 4) {
				return makeExceptionMessage(out exceptionMessage, "The code of the template is invalid");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"code"};
			List<object> values = new List<object>{code};
			
			return base.insert(columns, values);
		}

	}
}

