using System;

namespace _06.GenericCountMethodDouble
{
    public class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenericList<double> list = new GenericList<double>();

            for (int i = 0; i < n; i++)
            {
                list.List.Add(double.Parse(Console.ReadLine()));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            int count = list.CompareAndCount(elementToCompare);

            Console.WriteLine(count);
        }
    }
}
