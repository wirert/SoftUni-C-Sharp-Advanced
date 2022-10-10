using System;
using System.Collections.Generic;

namespace CustomStackClass
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> ints = new Stack<int>();
            

            CustomStack customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);

            customStack.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            customStack.Pop();

            customStack.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            

            Console.WriteLine(customStack.Count);
        }
    }
}
