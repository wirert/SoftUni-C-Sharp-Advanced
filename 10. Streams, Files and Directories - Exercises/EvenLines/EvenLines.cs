using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    using System;
    using static System.Net.Mime.MediaTypeNames;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder text = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int count = 0;


                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        char[] symbols = new[] { '-', ',', '.', '!', '?' };

                        foreach (var symbol in symbols)
                        {
                            line = line.Replace(symbol, '@');
                        }

                        string[] reversedArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

                        string reversedLine = string.Join(" ", reversedArray);

                        text.AppendLine(reversedLine);
                    }

                    count++;
                    line = reader.ReadLine();
                }
            }

            return text.ToString();
        }
    }
}
