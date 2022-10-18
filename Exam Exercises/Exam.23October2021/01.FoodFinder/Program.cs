using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Word[] words =
            {  new Word("pear"), new Word("flour"), new Word("pork"), new Word("olive") };

            var vowels = new Queue<char>(Console.ReadLine().ToCharArray());

            var consonants = new Stack<char>(Console.ReadLine().ToCharArray());

            while (consonants.Count != 0)
            {
                char vowel = vowels.Dequeue();
                vowels.Enqueue(vowel);
                char consonant = consonants.Pop();

                foreach (var word in words.Where(w => w.Count > 0))
                {
                    word.CheckChar(vowel);

                    word.CheckChar(consonant);
                }
            }

            var wordsFound = words.Where(w => w.Count == 0).ToArray();

            Console.WriteLine($"Words found: {wordsFound.Length}");

            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);
            }
        }
    }

    class Word
    {
        public Word(string name)
        {
            Name = name;
            LeftChars = name;
        }

        public string Name { get; set; }
        public string LeftChars { get; set; }
        public int Count { get { return LeftChars.Length; } }

        public void CheckChar(char ch)
        {
            if (LeftChars.Contains(ch))
            {
                int index = LeftChars.IndexOf(ch);

                LeftChars = LeftChars.Remove(index, 1);
            }
        }

        public override string ToString() => this.Name;
    }
}
