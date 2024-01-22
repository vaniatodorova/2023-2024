using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_egyptiandivide
{
    class Program
    {
        static void printEgyptian(int nr, int dr)
        {
            if (dr == 0 || nr == 0)
                return;
            if (dr % nr == 0)
            {
                Console.Write("1/" + dr / nr);
                return;
            }
            if (nr % dr == 0)
            {
                Console.Write(nr / dr);
                return;
            }
            if (nr > dr)
            {
                Console.Write(nr / dr + " + ");
                printEgyptian(nr % dr, dr);
                return;
            }
            int n = dr / nr + 1;
            Console.Write("1/" + n + " + ");
            printEgyptian(nr * n - dr, dr * n);
        }
        static void Main(string[] args)
        {
            int nr, dr;
            Console.Write("First Number: ");
            nr = int.Parse(Console.ReadLine());
            Console.Write("Second Number: ");
            dr = int.Parse(Console.ReadLine());
            Console.Write("Egyptian Fraction Representation of " +
                nr + "/" + dr + " is\n ");
            printEgyptian(nr, dr);
            Console.WriteLine();
        }
    }
}
