using System;

namespace _02_Starting_recursion
{
	class Program
	{
		static void fun(int n)
		{
			if (n > 0)
			{
				fun(n - 1);
				Console.Write(" " + n);
			}
		}
		static void Main(string[] args)
		{
			int x = 3;
			fun(x);
		}
	}
}
