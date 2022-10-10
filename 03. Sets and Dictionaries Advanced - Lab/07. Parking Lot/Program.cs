using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string[] command = Console.ReadLine().Split(", ");

            while (command[0] != "END")
            {
                if (command[0] == "IN")
                {
                    parking.Add(command[1]);
                }
                else
                {
                    if (parking.Contains(command[1]))
                        parking.Remove(command[1]);
                }

                command = Console.ReadLine().Split(", ");
            }

            if (!parking.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
