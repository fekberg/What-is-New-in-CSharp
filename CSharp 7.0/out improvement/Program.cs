using System;

namespace out_improvement
{
    class Program
    {
        public static void SetPoints(out int x, out int y)
        {
            x = 100;
            y = 200;
        }

        static void Main(string[] args)
        {
            SetPoints(out var x, out var y);

            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
