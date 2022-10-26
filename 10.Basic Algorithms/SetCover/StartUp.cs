namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            IList<int> universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToImmutableList();
            int numSets = int.Parse(Console.ReadLine());

            IList<int[]> sets = new List<int[]>();

            for (int i = 0; i < numSets; i++)
            {
                int[] set = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                sets.Add(set);
            }

            sets = sets.OrderByDescending(s => s.Length).ToList();

            List<int[]> result = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({result.Count}):");

            foreach (var set in result)
            {
                Console.WriteLine("{ " + $"{string.Join(", ", set)}" + " }");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> result = new List<int[]>();
            HashSet<int> ints = new HashSet<int>();

            foreach (var set in sets)
            {
                if (ints.Count == universe.Count)
                {
                    break;
                }

                bool isAllContained = true;
                bool isAllAlreadyAdd = true;

                foreach (var num in set)
                {
                    if (!universe.Contains(num))
                    {
                        isAllContained = false;
                        break;
                    }

                    if (!ints.Contains(num))
                    {
                        isAllAlreadyAdd = false;
                    }
                }

                if (isAllContained && !isAllAlreadyAdd)
                {
                    result.Add(set);
                    ints.UnionWith(set);
                }
            }

            return result;
        }
    }
}
