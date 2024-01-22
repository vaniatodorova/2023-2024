using System;

namespace _10_Separate_digits
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("\n\n Recursion : Display the individual digits of given number :\n");
			Console.Write("----------------------------------------------------------------\n");
			Console.Write(" Input any number : ");
			int num = Convert.ToInt32(Console.ReadLine());
			Console.Write(" The digits in the number {0} are : ", num);
			separateDigits(num);
			Console.Write("\n\n");
		}

		static void separateDigits(int n)
		{
			if (n < 10)
			{
				Console.Write("{0} ", n);
				return;
			}
			separateDigits(n / 10);
			Console.Write(" {0} ", n % 10);
		}
	}
}
