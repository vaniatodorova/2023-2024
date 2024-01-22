using System;

namespace _08_Print_natural
{
	class Program
	{
		static int printNatural(int stval, int ctr)
		{
			if (ctr < 1)
			{
				return stval;
			}
			ctr--;
			Console.Write(" {0} ", stval);
			return printNatural(stval + 1, ctr);
		}
		static void Main(string[] args)
		{
			Console.Write("\n\n Recursion : Print the first n natural number :\n");
			Console.Write("---------------------------------------------------\n");
			Console.Write(" How many numbers to print : ");
			int ctr = Convert.ToInt32(Console.ReadLine());
			printNatural(1, ctr);
			Console.Write("\n\n");
		}
	}
}
