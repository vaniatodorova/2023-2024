using System;

namespace _06_Recursive_method01
{
	class Program
	{
		//Calculate Sum Recursively
		public static int CSR(int n, int m)
		{
			int sum = n;
			if (n < m)
			{
				n++;
				return sum += CSR(n, m);
			}
			return sum;
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Enter number n: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter number n: ");
			int m = Convert.ToInt32(Console.ReadLine());
			int sum = CSR(n, m);
			Console.WriteLine(sum);
			Console.ReadKey();

		}
	}
}
