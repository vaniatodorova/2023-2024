using System;

namespace _03_Embedded_recursion
{
	class Program
	{
		static int fun(int n)
		{
			if (n > 100)
				return n - 10;

			return fun(fun(n + 11));
		}
		static void Main(string[] args)
		{
			int r;
			r = fun(95);
			Console.Write(" " + r);
		}
	}
}
