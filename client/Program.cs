using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using server.Models;
using System.Net.Http.Json;
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
            for (int i = 0; i <= 100; i++)
            {
                var response = await client.GetFromJsonAsync<AttemptResult>($"https://localhost:5001/{i}");

                if (response.AmIright)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was unsuccesful");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was unsuccesful.");
                }
            }
            Console.ReadKey();
        }
    }
}
