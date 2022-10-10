using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("asd","asd");

            Console.WriteLine( scale.AreEqual());
        }
    }
}
