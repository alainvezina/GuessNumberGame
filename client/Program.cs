using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public Program()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("https://localhost:5001");
        }

        static async Task Main(string[] args)
        {
            //Call example 

            for (int i = 0; i <= 100; i++)
            {
                var message = await client.GetStringAsync($"https://localhost:5001/{i}");
            }

            Console.ReadKey();
        }
    }
}
