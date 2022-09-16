using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boxes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int rackCapacity = int.Parse(Console.ReadLine());

            int numRacks = 1;
            int curRackCapacity = rackCapacity;

            while (boxes.Count != 0)
            {
                int curBox = boxes.Pop();

                if (curRackCapacity < rackCapacity && curBox > curRackCapacity)
                {
                    numRacks++;
                    curRackCapacity = rackCapacity;
                }

                if (curRackCapacity >= curBox)
                {
                    curRackCapacity -= curBox;
                }
                else
                {
                    numRacks++;
                    curRackCapacity = rackCapacity - (curBox - curRackCapacity);
                }
            }

            Console.WriteLine(numRacks);
        }
    }
}
