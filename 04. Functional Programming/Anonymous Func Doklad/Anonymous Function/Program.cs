using System;

namespace Anonymous_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> doubleNumber = delegate (int x)
            {
                return x * 2;
            };

            int result = doubleNumber(5); // result ще бъде 10
            Console.WriteLine(result);

        }
    }
}
