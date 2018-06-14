using System;

namespace Auto_Property_Initializers
{
    class Program
    {
        public static string Name { get; } = "Filip";
        
        static void Main(string[] args)
        {
            // Name = "Can't do that!";

            Console.WriteLine(Name);
        }
    }
}
