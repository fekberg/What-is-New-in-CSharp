using System;

namespace Infer_Tuple_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point();
            
            var tuple = (point.X, point.Y);
            
            //tuple.Item1, tuple.Item2

            Console.WriteLine(tuple.X);
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
