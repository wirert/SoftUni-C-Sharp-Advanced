using System;

namespace _02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number  = long.Parse(Console.ReadLine());
            
            Console.WriteLine(Factorial(number));
        }

        private static long Factorial(long number)
        {
            if (number == 1)
            {
                return 1;
            }

            return Factorial(number - 1) * number;
        }
    }
}
