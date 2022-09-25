using System.Text.RegularExpressions;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            StreamReader wordsReader = new StreamReader(wordsFilePath);
            StreamReader textReader = new StreamReader(textFilePath);
            StreamWriter outputWriter = new StreamWriter(outputFilePath);

            using (wordsReader)
            {
                string[] words = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

                using (textReader)
                {
                    string text = textReader.ReadToEnd().ToLower();

                    string pattern = @"\w+'*\w*";
                    var regex = new Regex(pattern);

                    var matches = regex.Matches(text);

                    foreach (string word in words)
                    {
                        wordOccurrences.Add(word, 0);

                        foreach (Match match in matches)
                        {
                            if (match.ToString() == word.ToLower())
                            {
                                wordOccurrences[word]++;
                            }
                        }
                    }
                }

                using (outputWriter)
                {
                    foreach (var word in wordOccurrences.OrderByDescending(w => w.Value))
                    {
                        outputWriter.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}