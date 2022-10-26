namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<int> coins = new List<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> target = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {target.Values.Sum()}");

            foreach (var coin in target.Where(c => c.Value > 0).OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            List<int> sortedCoins = coins.OrderBy(c => c).ToList();
            Dictionary<int, int> result = new Dictionary<int, int>();
            int index = sortedCoins.Count - 1;           

            while (targetSum != 0 && index >= 0)
            {
                int currSum = 0;
                int numCoins = targetSum / sortedCoins[index];

                if (numCoins == 0)
                {
                    index--;
                    continue;
                }
                else
                {
                    currSum = sortedCoins[index] * numCoins;
                    result.Add(sortedCoins[index], numCoins);
                    targetSum -= currSum;
                    index--;
                }
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException();                
            }

            return result;
        }
    }
}