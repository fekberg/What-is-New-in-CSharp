using System;
using System.Collections.Generic;
using static System.Console;

namespace Null_conditional_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Person[] {
                new Person { Name = "Filip" },
                null
            };

            ProcessPeople(people);

            Person[] otherPeople = null;

            WriteLine($"Who's first? {otherPeople?[0]?.Name ?? "None"}");
        }

        static void ProcessPeople(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                WriteLine($"{person?.Name ?? "Unknown"} lives at " +
                    $"{person?.Address?.Street ?? "No idea"}");
            }
        }
    }
    
    class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    class Address
    {
        public string Street { get; set; } = "Not Specified";
    }
}
