using System;
using System.Collections.Generic;
	
public class coroutineExample {
		
	public static IEnumerable<int> Fibonacci ()
	{
		yield return 1;
		int a = 0;
		int b = 1;
		int c;
		while (true) {
			c = a + b;
			yield return c;
			a = b;
			b = c;
		}
	}
	
	public static void Main ()
	{
		int n = 10;
		foreach (int f in Fibonacci ()) {
			n--;
			Console.WriteLine (f);
			if(n <= 0) {
				break;
			}
		}
	}
		
}
