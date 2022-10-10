using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var openBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int index = openBrackets.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1));
                }
            }
        }
    }
}
