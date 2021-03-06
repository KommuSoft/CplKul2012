using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public class Util
	{
		public Util () {}

		public static List<T> parse<T> (string text) where T : IConvertible
		{
			text = text.Remove (startIndex: 0, count: 1);
			text = text.Remove (startIndex: text.Length-1, count: 1);
			string[] splitted = text.Split (',');

			List<T> result = new List<T>(); 
			foreach (string s in splitted) {
				if (s != ""){
					string cleaned = s.Replace('$', ' ');
					result.Add((T)Convert.ChangeType(cleaned, typeof(T)));
				}
			}

			return result;
		}

		public static string parse (object o)
		{
			if (o.GetType () == typeof(string)) {
				return "'" + o + "'";	
			} else if (o.GetType () == typeof(DateTime)) {
				throw new InvalidCastException("A DateTime should be parsed with Util.toDate or Util.toTime.");
			} else if (o.GetType () == typeof(decimal)) {
				return o.ToString();
			} else if (o.GetType() == typeof(List<int>)){
				return "'{" + string.Join(", ", ((List<int>) o).Select(X=>X.ToString()).ToArray()) + "}'";
			} else {	
				return o.ToString();
			}
		}

		private static void checkIfDateTime (object o)
		{
			if (o.GetType() != typeof(DateTime)) {
				throw new InvalidCastException("Argument should be of type DateTime");
			}
		}

		private static void checkIfTimespan (object o)
		{
			if (o.GetType () != typeof(TimeSpan)) {
				throw new InvalidCastException("Arguement should be of type TimeSpan");
			}
		}

		public static string toTimeSpan (object o)
		{
			checkIfTimespan(o);
			TimeSpan t = (TimeSpan) o;
			return t.Hours + ":" + t.Minutes + ":" + t.Seconds;
		}

		public static string toTime (object o)
		{
			checkIfDateTime(o);
			DateTime dt = (DateTime) o;
			return dt.Hour + ":" + dt.Minute + ":" + dt.Second;
		}

		public static string toDate (object o)
		{
			checkIfDateTime(o);
			DateTime dt = (DateTime) o;
			return dt.Month + "/" + dt.Day + "/" + dt.Year;
		}

		public static string fetchOperator (Type type)
		{
			if (type == typeof(string)) {
				return " ILIKE ";
			} else if (type == typeof(int)) {
				return " = ";
			} else {
				return " =";
			}
		}

		public static void split (string code, ref string airlineCode, ref string digits)
		{
			foreach (char c in code) {
				if (Char.IsLetter (c)) {
					airlineCode += c;
				} else if (Char.IsDigit (c)) {
					digits += c;
				}
			}
		}
	}
}

