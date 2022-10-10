using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numPeople; i++)
            {
                string[] inputPerson = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(inputPerson[0], int.Parse(inputPerson[1]));

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
