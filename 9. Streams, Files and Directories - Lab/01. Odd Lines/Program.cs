using System;
using System.IO;

namespace _01._Odd_Lines
{
    internal class Program
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                string line = reader.ReadLine();

                int counter = 0;

                using (writer)
                {

                    while (line != null)
                    {

                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
