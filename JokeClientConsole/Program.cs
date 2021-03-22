using System;
using System.Threading.Tasks;
using JokeService;
using Grpc.Net.Client;
namespace JokeClientConsole
{
    class Program
    {
        static string[] results = new string[500/*50*/];
        static char key;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new JokeCheck.JokeCheckClient(channel);
            var jokeRequest = new JokeRequest { Name = "Maggie", Category = "career" };
            var reply = await client.CheckJokeRequestAsync(jokeRequest);

            Console.WriteLine($"Hello {jokeRequest.Name}! Enjoy the joke for {jokeRequest.Category.ToUpper()} category: {reply.Message}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        private static void PrintResults()
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
            }
        }

      
    }
}
