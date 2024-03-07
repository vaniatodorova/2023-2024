using System;

namespace Functions_with_internal_state
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Func<int, int>> createAccumulator = () =>
            {
                int sum = 0;
                return (int x) =>
                {
                    int currentValue = sum; // Capture the current value of sum
                    currentValue += x;
                    return currentValue;
                };
            };

            var accumulator = createAccumulator();
            Console.WriteLine(accumulator(5)); // Outputs 5
            Console.WriteLine(accumulator(3)); // Outputs 3

        }
    }
}
