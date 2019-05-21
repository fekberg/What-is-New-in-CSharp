using System.Net.Http;
using System.Threading.Tasks;

namespace Using_Declarations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            
            await client.GetAsync("https://fekberg.com");
        }
    }
}
