using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPumps = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();

            for (int i = 0; i < numPumps; i++)
            {
                int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pump[0] - pump[1]);
            }

            int startPump = -1;

            for (int i = 0; i < numPumps; i++)
            {

                int pump = queue.Dequeue();
                queue.Enqueue(pump);

                if (pump < 0) continue;

                startPump = i;
                int fuel = pump;
                bool isStartPump = true;

                foreach (var station in queue)
                {
                    fuel += station;

                    if (fuel >= 0) continue;

                    isStartPump = false;
                    break;
                }

                if (isStartPump) break;
            }

            Console.WriteLine(startPump);
        }
    }
}
