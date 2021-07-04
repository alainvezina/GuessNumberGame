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
        private static HttpClient client;

        private static void GenerateClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("https://localhost:5001");
        }

        static async Task Main(string[] args)
        {
            if (client == null)
                GenerateClient();

            await ScenarioFrom1To100();
            await ScenarioRandomNumberBetween();
        }

        private static async Task ScenarioFrom1To100()
        {
            await client.GetStringAsync("reset");

            for (int i = 0; i <= 100; i++)
            {
                var response = await client.GetFromJsonAsync<AttemptResult>(i.ToString());

                if (response.AmIright)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was sucessfull");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was unsuccesful.");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private static async Task ScenarioRandomNumberBetween()
        {
            await client.GetStringAsync("reset");
            var rand = new Random();
            int numberOfAttempts = 0;
            int input = 50;
            int lowNumber = 0;
            int maxNumber = 100;
            
            do
            {
                var response = await client.GetFromJsonAsync<AttemptResult>(input.ToString());

                if (response.AmIright)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was sucessfull");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    if (response.IsLowerOrEqual)
                    {
                        maxNumber = input;
                        input = rand.Next(lowNumber, input);
                    }
                    else
                    {
                        lowNumber = input + 1;
                        input = rand.Next(lowNumber, maxNumber);
                    }    

                    Console.WriteLine($"Attempt #{response.NumberOfAttempts} with number {response.Input} was unsuccesful.");
                }

                numberOfAttempts++;
            } while (numberOfAttempts <= 100);

            Console.ReadKey();
            Console.Clear();
        }
    }
}
