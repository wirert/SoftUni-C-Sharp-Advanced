using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class Startup
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1).ToList();
            ListyIterator<string> listy = new ListyIterator<string>(input);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());

                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());

                        break;
                    case "Print":
                        try
                        {
                            listy.Print();
                        }
                        catch (InvalidOperationException exeption)
                        {
                            Console.WriteLine(exeption.Message);
                        }

                        break;
                }
            }
        }
    }
}
