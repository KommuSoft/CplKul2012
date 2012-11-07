using System;
using System.Collections.Generic;
using System.Linq;

public class LinqExample {

	public static void Main ()
	{
		Tuple<int, int>[] data = new Tuple<int, int>[] { new Tuple<int, int> (2, 7), new Tuple<int, int> (3, 6), new Tuple<int, int> (1, -10) };
		IEnumerable<int> result = from x in data
			where x.Item1 < 3
			select x.Item1 * x.Item2;
		Console.WriteLine(string.Join(",",result));//result: 14,-10
		
	}
	
	
}

