using System;
using System.Text.RegularExpressions;

namespace DSLImplementation.UserInterface {

	public static class Parsers {

		public static string StringParser (string val) {
			if(val == string.Empty) {
				return null;
			}
			return val;
		}
		public static object StringObjectParser (string val) {
			if(val == string.Empty) {
				return null;
			}
			return val;
		}
		public static Parse<object> GenerateRegexMatchingParser (string regex) {
			Regex rgx = new Regex(regex,RegexOptions.Compiled|RegexOptions.ExplicitCapture);
			return x => RegexMatchingParser(rgx,x);
		}
		public static object RegexMatchingParser (Regex rgx, string text) {
			if(text == null || text == string.Empty) {
				return null;
			}
			else if(rgx.IsMatch(text)) {
				return text;
			}
			else {
				throw new Exception("Text doesn't match constraints!");
			}
		}
		public static object DateTimeParser (string val) {
			return DateTime.Parse(val);
		}
		public static object Int32Parser (string val) {
			return Int32.Parse(val);
		}

	}
}

