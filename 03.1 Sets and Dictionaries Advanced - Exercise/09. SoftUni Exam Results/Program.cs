using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            SortedDictionary<string, int> contestResults = new SortedDictionary<string, int>();

            string[] command = Console.ReadLine().Split('-');

            while (command[0] != "exam finished")
            {
                string name = command[0];

                if (command[1] == "banned")
                {
                    contestResults.Remove(name);
                }
                else
                {
                    string language = command[1];
                    int points = int.Parse(command[2]);

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;

                    if (!contestResults.ContainsKey(name))
                    {
                        contestResults.Add(name, points);
                    }
                    else
                    {
                        if (contestResults[name] < points)
                        {
                            contestResults[name] = points;
                        }
                    }
                }

                command = Console.ReadLine().Split('-');
            }

            Console.WriteLine("Results:");

            foreach (var contestant in contestResults.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{contestant.Key} | {contestant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions
                         .OrderByDescending(l => l.Value)
                         .ThenBy(l => l.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
