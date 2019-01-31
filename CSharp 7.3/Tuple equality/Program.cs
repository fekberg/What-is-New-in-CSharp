using System;

namespace Tuple_equality
{
    class Program
    {
        static (int x, int y) Compute()
        {
            return (100, 200);
        }

        static void Main(string[] args)
        {
            var result = Compute();
            
            Console.WriteLine(result == (100, 200));
        }
    }
}
