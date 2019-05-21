using System;
using System.Threading.Tasks;

namespace Nullable_references
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var repository = new PersonRepository();

            var person = await repository.Get();

            person ??= new Person();

            InsertOrUpdate(person);
        }

        static void InsertOrUpdate(Person person)
        {
            Console.WriteLine(person.Name.Length);
        }
    }

    class PersonRepository
    {
        public Task<Person> Get() => Task.FromResult((Person)null);
    }

    class Person
    {
        public string? Name { get; set; }

        public Person()
        {
        }
    }
}
