using System;
using System.Collections.Generic;

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

		public static string parse (Object o)
		{
			if (o.GetType () == typeof(string)) {
				return "'" + o + "'";	
			} else if (o.GetType () == typeof(DateTime)) {
				throw new NotImplementedException();
			} else if (o.GetType () == typeof(decimal)) {
				throw new NotImplementedException();
			} else {	
				return o.ToString();
			}
		}
	}
}

