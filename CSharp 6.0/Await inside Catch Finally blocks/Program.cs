using System;
using System.Threading.Tasks;

namespace Await_inside_Catch_Finally_blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public async Task RunAsync()
        {
            try
            {
                await Task.Delay(1);
            }
            catch (Exception)
            {
                // Clean-up!
                await Task.Delay(1);
            }
            finally
            {
                // Dispatch completion message!
                await Task.Delay(1);
            }
        }
    }
}
