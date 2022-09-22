using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shopProducts = new Dictionary<string, Dictionary<string, double>>();

            string[] command = Console.ReadLine().Split(", ");

            while (command[0] != "Revision")
            {
                string shop = command[0];
                string product = command[1];
                double productPrice = double.Parse(command[2]);

                if (!shopProducts.ContainsKey(shop))
                {
                    shopProducts.Add(shop, new Dictionary<string, double>());
                }

                if (!shopProducts[shop].ContainsKey(product))
                {
                    shopProducts[shop].Add(product, productPrice);
                }
                else
                {
                    shopProducts[shop][product] = productPrice;
                }

                command = Console.ReadLine().Split(", ");
            }

            foreach (var shop in shopProducts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
