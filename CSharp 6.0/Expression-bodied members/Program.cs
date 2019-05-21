using System;

namespace Expression_bodied_members
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Name = "Filip" };

            Console.WriteLine(person);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public override string ToString() => $"My name is {Name}";
    }
}
