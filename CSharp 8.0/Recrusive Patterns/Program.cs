using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recrusive_Patterns
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region ExplainShape

            Shape shape = new Rectangle { Width = 100, Height = 0 };
            // new Triangle { A = 10, B = 10, C = 30 };
            
            var result = ExplainShape(shape);

            Console.WriteLine(result);

            #endregion

            #region GetShapeFrom HttpResponseMessage

            shape = await GetShapeFrom(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
                // StatusCode = HttpStatusCode.Forbidden
                // StatusCode = HttpStatusCode.NotModified
                // StatusCode = HttpStatusCode.BadRequest
                // StatusCode = HttpStatusCode.SeeOther
            });

            Console.WriteLine(ExplainShape(shape));

            #endregion
        }

        static string ExplainShape(Shape shape)
        {
            return shape switch
            {
                Triangle t when t.A != t.B => $"A != B, ({t.A} != {t.B})",

                #region Tuple Pattern

                Triangle (var a, var b, var c, (_, var y)) => $"A: {a}, B: {b}, C: {c}, Y: {y}",

                #endregion

                #region Positional Pattern

                Rectangle (0, 0, _) r => "0, 0",

                #endregion

                #region Property Pattern

                Rectangle { Width: 100 } r => $"Width: {r.Width}",
                
                #endregion

                #region Any rectangle
                Rectangle r => $"Point X: {r.Point.X}, Y: {r.Point.Y}",
                #endregion

                #region Default Pattern

                _ => "Other shapes"

                #endregion
            };
        }




        static string VisibilityFrom(bool? state)
        {
            return state switch
            {
                true => "Visible",
                false => "Hidden",
                _ => "Blink"
            };
        }




        static async Task<Shape> GetShapeFrom(HttpResponseMessage message)
        {
            var shape = message switch
            {
                { StatusCode: HttpStatusCode.OK } => await ExtractShape(message),
                { StatusCode: HttpStatusCode.NotModified } => await FromCache(),
                { StatusCode: HttpStatusCode.BadRequest } => throw new Exception("Go away"),
                { StatusCode: HttpStatusCode.Forbidden } => throw new Exception("Nothing to see here"),
                _ => throw new Exception("No idea how to handle this")
            };

            return shape;
        }




        #region Data

        private static Task<Shape> FromCache()
            => Task.FromResult((Shape)new Rectangle { Height = 200, Width = 400 });

        public static Task<Shape> ExtractShape(HttpResponseMessage message) 
            => Task.FromResult((Shape)new Triangle { A = 100, B = 100, C = 300, Point = new Point { X = 0, Y = 100} });

        #endregion
    }

    abstract class Shape
    {
        public Point Point { get; set; }
    }

    class Triangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public void Deconstruct(out int a, out int b, out int c, out Point point)
        {
            a = A;
            b = B;
            c = C;

            point = Point;
        }
    }

    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Deconstruct(out int width, out int height, out Point point)
        {
            width = Width;
            height = Height;
            point = Point;
        }

    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
