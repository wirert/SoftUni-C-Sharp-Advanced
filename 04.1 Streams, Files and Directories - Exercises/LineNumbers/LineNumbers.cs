using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadLines(inputFilePath).ToArray();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                int letters = lines[i].Count(ch => char.IsLetter(ch));
                int punctuations = lines[i].Count(ch => char.IsPunctuation(ch));

                text.AppendLine($"Line {i + 1}: {lines[i]} ({letters})({punctuations})");
            }

            File.WriteAllText(outputFilePath, text.ToString());
        }
    }
}
