using System;

namespace ref_returns
{
    class Program
    {
        static void Main(string[] args)
        {
            ref int ElementAt(int[] src, int position)
            {
                return ref src[position];
            }

            var source = new[] { 1, 2 };

            Console.WriteLine(source[1]);

            ElementAt(source, 1) = 10;  // source[1] = 10

            Console.WriteLine(source[1]);
        }
    }
}
