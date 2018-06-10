using System;

namespace ref_readonly_and_in_parameters
{
    class Program
    {
        static ref readonly int Compute(ref int x, in int y)
        {
            x = y + 1;
            // y = y + 2;

            return ref y;
        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;

            var z = Compute(x: ref x, // non-trailing named arguments
                in y); // "in" is redudant

            Console.WriteLine($"x: {x}, y: {y}, z: {z}");
        }
    }
}
