using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x = ");
            double x = double.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(Y(x));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static double Y(double x)
        {
            try
            {
                if (x < 0.5) throw new TheRootExpressionLessThanZeroException();
                else if (x == 0.5) throw new ZeroDivisionException();
                else return x / (Math.Sqrt(2 * x - 1));
            }
            catch
            {
                throw;
            }
        }
    }

    public class ZeroDivisionException : Exception
    {
        private const String message = "Знаменатель обращается в ноль";
        public ZeroDivisionException () : base (message)
        {
        }
    }
    public class TheRootExpressionLessThanZeroException : Exception
    {
        private const String message = "Подкоренное выражение в знаменателе меньше нуля";
        public TheRootExpressionLessThanZeroException () : base (message)
        {
        }
    }
}
