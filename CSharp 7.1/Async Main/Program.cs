using System;
using System.Threading.Tasks;

namespace Async_Main
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(1000);

            Console.WriteLine("Wow!");

            Shape s = default;

            Console.WriteLine(s);
        }
    }

    class Shape { };
}
