using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            string cmd = null;
            int carsPassed = 0;

            while ((cmd = Console.ReadLine()) != "END")
            {

                if (cmd != "green")
                {
                    queue.Enqueue(cmd);
                }
                else
                {
                    int time = greenDuration;

                    while (queue.Any() && time > 0)
                    {
                        string curCar = queue.Dequeue();

                        if (curCar.Length < time)
                        {
                            time -= curCar.Length;
                            carsPassed++;
                        }
                        else
                        {
                            if (curCar.Length > time + freeWindow)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{curCar} was hit at {curCar[time + freeWindow]}.");
                                return;
                            }

                            time -= curCar.Length;
                            carsPassed++;
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
