using System;

namespace Pattern_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Triangle();

            switch (shape)
            {
                case Triangle t:
                    Console.WriteLine(
                    $"A: {t.A} " +
                    $"B: {t.B} " +
                    $"C: {t.C}");
                    break;
                case Rectangle r:
                    Console.WriteLine(
                    $"X: {r.X} " +
                    $"Y: {r.Y} " +
                    $"Height: {r.Height} " +
                    $"Width: {r.Width}");
                    break;
            }

        }
    }

    abstract class Shape { }

    class Triangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
    class Rectangle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
