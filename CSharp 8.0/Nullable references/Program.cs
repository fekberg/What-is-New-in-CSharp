using System;

namespace Nullable_references
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();

            Print(p);
        }

        static void Print(Person? p)
        {
            Console.WriteLine((null as Person)!.Name?.Length);
        }

    }

    class Person
    { 
        public string? Name { get; set; }

        public Person()
        {

        }
    }
}
