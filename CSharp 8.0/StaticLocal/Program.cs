using System;

namespace Static_Local
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new MyApp();

            var result = app.Compute();

            Console.WriteLine(result);
        }
    }

    class MyApp
    {
        public string Name { get; set; }

        public int Compute()
        {
            int value = 10;

            static int OverEngineeredMethod(int a)
            {
                return Name.Length + value + a;
            }

            return OverEngineeredMethod(20);
        }
    }
}
