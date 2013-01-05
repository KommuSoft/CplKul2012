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
				string cleaned = s.Replace('$', ' ');
				result.Add((T)Convert.ChangeType(cleaned, typeof(T)));
			}

			return result;
		}

		public static string parse (object o)
		{
			if (o.GetType () == typeof(string)) {
				return "'" + o + "'";	
			} else if (o.GetType () == typeof(DateTime)) {
				//TODO smijt andere error
				throw new NotImplementedException();
				//TODO implementeer dit
			} else if (o.GetType () == typeof(decimal)) {
				throw new NotImplementedException();
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
	}
}

