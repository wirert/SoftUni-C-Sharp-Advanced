using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(10, "daf");

            int[] ints = ArrayCreator.Create(20, 5);

            Console.WriteLine(string.Join(',', strings));
            Console.WriteLine(string.Join(',', ints));
        }
    }
}
