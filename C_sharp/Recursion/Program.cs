using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Alphabet();
        }
        static double Pow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n < 0)
            {
                return 1/(x*Pow(x, Math.Abs(n)-1));
            }
            else
            {
                return x*Pow(x, n-1);
            }
        }

        static void Sequence(int n = 0, int i = 1) //  n = 7
        {
            if (i == n + 1)
            {
                return;
            }
            for (int j = i; j >= 1; j--)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
            Sequence(n, ++i);
        }
        
        static void Alphabet(int i = 80, int n = 0)
        {
            const String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const int alphabetLength = 26;
            
            if (n == 51)
            {
                return;
            }
            if (n <= 25)
            {
                String tabs = string.Join("", Enumerable.Repeat(" ", n));
                Console.Write(tabs);
                Console.Write(string.Join("", Enumerable.Repeat(alphabet[n], i)));
                Console.WriteLine();
                Alphabet(i -= 2, ++n);
            }
            else if (n <= 50)
            {
                String tabs = string.Join("", Enumerable.Repeat(" ", 2 * alphabetLength - n - 2));
                Console.Write(tabs);
                Console.Write(string.Join("", Enumerable.Repeat(alphabet[2 * alphabetLength - n - 2], i+4)));
                Console.WriteLine();
                Alphabet(i += 2, ++n);
            }
        }
    }
}
