using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            string command = null;
            int count = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    for (int i = 1; i <= carsToPass; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
