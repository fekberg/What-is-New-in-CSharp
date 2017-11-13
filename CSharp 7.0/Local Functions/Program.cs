using System;

namespace Local_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Digit Separator & Binary Literals

            var number = 0b0000_0000_0001_0000; // 16

            var value = 2_1;
            
            // Call a local function
            Console.WriteLine($"Calcuate for: {value}");

            var result = Calculate(value);

            Console.WriteLine(result);
        }

        public static int Calculate(int x)
        {
            int fib(int n)
            {
                if (n == 0 || n == 1) return n;

                return fib(n - 1) + fib(n - 2);
            }

            return fib(x);
        }

    }
}
