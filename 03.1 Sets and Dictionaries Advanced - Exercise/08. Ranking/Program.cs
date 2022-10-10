
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasswords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> contestsResults = new SortedDictionary<string, Dictionary<string, int>>();

            string[] inputContest = Console.ReadLine().Split(':');

            while (inputContest[0] != "end of contests")
            {
                if (!contestsPasswords.ContainsKey(inputContest[0]))
                {
                    contestsPasswords.Add(inputContest[0], inputContest[1]);
                }

                contestsPasswords[inputContest[0]] = inputContest[1];

                inputContest = Console.ReadLine().Split(':');
            }

            string[] input = Console.ReadLine().Split("=>");

            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string pass = input[1];

                if (!contestsPasswords.ContainsKey(contest)
                    || contestsPasswords.First(c => c.Key == contest).Value != pass)
                {
                    input = Console.ReadLine().Split("=>");
                    continue;
                }

                string contestantName = input[2];
                int resultContest = int.Parse(input[3]);

                if (!contestsResults.ContainsKey(contestantName))
                {
                    contestsResults.Add(contestantName, new Dictionary<string, int>());
                }

                if (!contestsResults[contestantName].ContainsKey(contest))
                {
                    contestsResults[contestantName].Add(contest, resultContest);
                }
                else
                {
                    if (contestsResults[contestantName][contest] < resultContest)
                    {
                        contestsResults[contestantName][contest] = resultContest;
                    }
                }

                input = Console.ReadLine().Split("=>");
            }

            string bestName = null;
            int bestPointsSum = -1;

            foreach (var contestant in contestsResults)
            {
                int curSum = contestant.Value.Sum(p => p.Value);

                if (curSum > bestPointsSum)
                {
                    bestPointsSum = curSum;
                    bestName = contestant.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPointsSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var contestant in contestsResults)
            {
                Console.WriteLine(contestant.Key);

                foreach (var contest in contestant.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
