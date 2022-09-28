using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TakePeopleFromConsole(out List<Person> people);

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string,int, int, bool> filter = (cond, age, filter) => cond == "older"? age >= filter: age < filter;

            Func<Person, string[], string> formatOutput = (person, format) =>
            {
                string formatString = null;

                if (format.Length == 2)
                {
                    formatString = format[0] == "name" ? "{0} - {1}" : "{1} - {0}";
                }
                else
                {
                    formatString = format[0] == "name" ? "{0}" : "{1}";
                }

                return string.Format(formatString, person.Name, person.Age);
            };

            Console.WriteLine(string.Join(Environment.NewLine, 
                people.Where(person => filter(condition, person.Age, ageFilter))
                    .Select(person => formatOutput(person, format))));
        }

        private static void TakePeopleFromConsole(out List<Person> people)
        {
            int n = int.Parse(Console.ReadLine());

            people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
