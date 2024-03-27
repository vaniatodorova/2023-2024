using System;

namespace abstraction_by_functions
{
    public class FunctionalAbstraction
    {
        // Функция, която удвоява дадено число
        public static int Double(int x)
        {
            return x * 2;
        }

        // Функция, която прилага дадена функция върху всеки елемент на масив
        public static int[] ApplyFunction(int[] array, Func<int, int> function)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = function(array[i]);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Прилагане на абстракция чрез функции
            int[] doubledNumbers = FunctionalAbstraction.ApplyFunction(numbers, FunctionalAbstraction.Double);

            Console.WriteLine("Doubled numbers:");
            foreach (int num in doubledNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
