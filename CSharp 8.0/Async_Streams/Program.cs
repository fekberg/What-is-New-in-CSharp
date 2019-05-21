using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Async_Streams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Lyrics
            Console.WriteLine(Environment.NewLine + Environment.NewLine);

            await foreach (var line in GetLyrics())
            {
                Console.WriteLine(line);
            }
            #endregion
        }

        public static async IAsyncEnumerable<int> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return await Task.Delay(300).ContinueWith(_ => i);
            }
        }

        public static async IAsyncEnumerable<string> GetLyrics()
        {
            using var stream = new StreamReader(@"C:\Code\lyrics.txt");

            string line;
            while((line = await stream.ReadLineAsync()) != null)
            {
                yield return line;

                await Task.Delay(400);
            }
        }
    }
}
