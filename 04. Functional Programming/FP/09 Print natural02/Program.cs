using System;

namespace _09_Print_natural02
{
	class Program
	{
		static int printNatural(int ctr, int stval)
		{
			if (ctr < 1)
			{
				return stval;
			}
			Console.Write(" {0} ", ctr);
			ctr--;
			return printNatural(ctr, stval);
		}
		static void Main(string[] args)
		{
			Console.Write("\n\n Recursion : Print the first natural numbers from n to 1 :\n");
			Console.Write("---------------------------------------------------\n");
			Console.Write(" How many numbers to print : ");
			int ctr = Convert.ToInt32(Console.ReadLine());
			printNatural(ctr, 1);
			Console.Write("\n\n");
		}
	}
}
