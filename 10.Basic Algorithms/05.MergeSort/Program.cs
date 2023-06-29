using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(String.Join(" ", MergeSort(arr.ToList())));
        }

        public static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            List<int> leftList = MergeSort(list.GetRange(0, list.Count / 2));
            List<int> rightList = MergeSort(list.GetRange(list.Count / 2, list.Count - list.Count / 2));

            return CombineArrays(leftList, rightList);
        }

        private static List<int> CombineArrays(List<int> leftList, List<int> rightList)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftList.Count && rightIndex < rightList.Count)
            {
                if (leftList[leftIndex] <= rightList[rightIndex])
                {
                    sortedList.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < leftList.Count; i++)
            {
                sortedList.Add(leftList[i]);
            }

            for (int i = rightIndex; i < rightList.Count; i++)
            {
                sortedList.Add(rightList[i]);
            }

            return sortedList;
        }
    }
}
