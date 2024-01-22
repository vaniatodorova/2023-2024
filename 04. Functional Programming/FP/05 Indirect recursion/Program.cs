using System;

namespace _05_Indirect_recursion
{
	class Program
	{
		static void funA(int n)
		{
			if (n > 0)
			{
				Console.Write(" " + n);
				funB(n - 1);
			}
		}
		static void funB(int n)
		{
			if (n > 1)
			{
				Console.Write(" " + n);
				funA(n / 2);
			}
		}
		static void Main(string[] args)
		{
			funA(20);
		}
	}
}
