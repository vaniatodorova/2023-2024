using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_minimalcoins
{
    class Program
    {
        static int[] deno = {1,2,5,10,20,
                             50,100,500,1000};
        static int n = deno.Length;
        static void findMin(int V)
        {
            List<int> ans = new List<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                while (V >= deno[i])
                {
                    V -= deno[i];
                    ans.Add(deno[i]);
                }
            }
            for (int i = 0; i < ans.Count; i++)
            {
                Console.Write(" " + ans[i]);
            }
        }
        static void Main(string[] args)
        {
            int n;
            Console.Write("Change: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Following is minimal number of change for " + n + ": ");
            findMin(n);
            Console.WriteLine();
        }
    }
}
