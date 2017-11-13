using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exception_Filters
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static async Task RunAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://www.google.com");

                    var content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
            {
                // retry
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.NameResolutionFailure)
            {
                // flight mode?
            }
        }
    }
}
