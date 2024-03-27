using System;
using System.Collections.Generic;
using System.Linq;

namespace calculations_on_lists
{
    public class ListCalculations
    {
        // Функция, която събира всички числа в даден списък
        public static int Sum(List<int> numbers)
        {
            Func<List<int>, int> sumFunc = (nums) => nums.Sum();
            return sumFunc(numbers);
        }

        // Функция, която намира средното аритметично на числата в даден списък
        public static double Average(List<int> numbers)
        {
            Func<List<int>, double> averageFunc = (nums) => nums.Average();
            return averageFunc(numbers);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Изчисления върху списъци
            int sum = ListCalculations.Sum(numbers);
            double average = ListCalculations.Average(numbers);

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);
        }
    }
}
