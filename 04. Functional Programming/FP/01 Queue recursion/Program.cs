using System;

namespace _01_Queue_recursion
{
	class Program
	{
		static void fun(int n)
		{
			if (n > 0)
			{
				Console.Write(n + " ");
				fun(n - 1);
			}
		}
		static void Main(string[] args)
		{
			int x = 3;
			fun(x);
		}
	}
}
