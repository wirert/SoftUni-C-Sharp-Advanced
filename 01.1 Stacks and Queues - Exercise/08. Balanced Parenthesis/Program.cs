using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            var openBrackets = new Stack<char>(input);
            bool isBalanced = true;

            foreach (char bracket in input)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                else
                {
                    if (openBrackets.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    if ((bracket == '}' && openBrackets.Peek() == '{')
                        || (bracket == ']' && openBrackets.Peek() == '[')
                        || (bracket == ')' && openBrackets.Peek() == '('))
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}