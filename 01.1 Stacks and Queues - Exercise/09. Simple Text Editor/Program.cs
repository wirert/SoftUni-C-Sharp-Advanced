using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            var undo = new Stack<string>();
            undo.Push("");

            for (int i = 0; i < n; i++)
            {
                string[] action = Console.ReadLine().Split(' ');

                switch (action[0])
                {
                    case "1":
                        undo.Push(text.ToString());
                        text.Append(action[1]);
                        break;
                    case "2":
                        int elementsToRemove = int.Parse(action[1]);
                        undo.Push(text.ToString());
                        text = text.Remove(text.Length - elementsToRemove, elementsToRemove);
                        break;
                    case "3":
                        int index = int.Parse(action[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        var previousText = new StringBuilder();
                        text = previousText.Append(undo.Pop());
                        break;
                }
            }

        }
    }
}
