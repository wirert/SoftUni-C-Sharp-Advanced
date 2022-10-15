using System;
using System.Linq;

namespace _03.Stack
{
    public class Startup
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            int[] inputElements = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(int.Parse)
                .ToArray();

            stack.Push(inputElements);

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Push":
                        stack.Push(command.Skip(1).Select(int.Parse).ToArray());
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException exeption)
                        {

                            Console.WriteLine(exeption.Message);
                        }

                        break;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (stack.Count == 0) return;

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
