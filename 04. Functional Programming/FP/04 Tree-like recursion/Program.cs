using System;

namespace _04_Tree_like_recursion
{
	class Program
	{
		static void fun(int n)
		{
			if (n > 0)
			{
				Console.Write(" " + n);
				fun(n - 1);
				fun(n - 1);
			}
		}
		static void Main(string[] args)
		{
			fun(3);
		}
	}
}
