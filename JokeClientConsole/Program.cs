using System;
using System.Threading.Tasks;
using JokeService;
using Grpc.Net.Client;
namespace JokeClientConsole
{
    class Program
    {
        static string[] results = new string[50];
        static char key;
        static ConsolePrinter printer = new ConsolePrinter();
        static string endpoint = "https://api.chucknorris.io";
        static async Task Main(string[] args)
        {

            printer.Value("Press ? to get instructions.").ToString();
            if (Console.ReadLine() == "?")
            {
                while (true)
                {
                    // The port number(5001) must match the port of the gRPC server.
                    var channel = GrpcChannel.ForAddress("https://localhost:5001");
                    var client = new JokeCheck.JokeCheckClient(channel);

                    printer.Value("Press c to get categories").ToString();
                    printer.Value("Press r to get random jokes").ToString();
                    GetEnteredKey(Console.ReadKey());

                    if (key == 'c')
                    {
                        var request = new CategoryRequest();
                        request.Uri = endpoint;
                        var reply = await client.CheckJokeCategoryRequestAsync(request);
                        Console.WriteLine($"Hello, you can select any category from: {reply.Message}"); 
                    }

                    if (key == 'r')
                    {

                        var jokeRequest = new JokeRequest();

                        //printer.Value("Want to use a random name? y/n").ToString();
                        //GetEnteredKey(Console.ReadKey());
                        //if (key == 'y')
                        //{
                        //    GetNames();
                        //}

                        printer.Value("Want to specify a category? y/n").ToString();
                        GetEnteredKey(Console.ReadKey());
                        if (key == 'y')
                        {

                            printer.Value("Enter a category:").ToString();

                            jokeRequest.Category = Console.ReadLine();
                        }
                        //else
                        //{
                            //printer.Value("How many jokes do you want? (1-9)").ToString();
                            //int n = Int32.Parse(Console.ReadLine());
                           // GetRandomJokes(null, n);
                           // PrintResults();
                       // }

                        printer.Value("How many jokes do you want? (1-9)").ToString();
                        int n = Int32.Parse(Console.ReadLine());
                        jokeRequest.Number = n;
                        jokeRequest.Uri = endpoint;
                        var reply = new JokeReply();
                        var success = true;
                        try
                        {
                            reply = await client.CheckJokeRequestAsync(jokeRequest);
                        }
                        catch (Exception ex)
                        {
                            //To do: logger ex
                           
                            reply.Message = "Joke service is not available at this moment. Please come back later.";
                            success = false;
                        }
                        Console.WriteLine($"Hello {jokeRequest.FirstName} {jokeRequest.LastName}!");
                        if (success) {
                            Console.WriteLine($"Enjoy the joke for {jokeRequest.Category.ToUpper()} category: {reply.Message}");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, {reply.Message}");
                        }
                    }

                   // Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }


        private static void PrintResults()
        {
            printer.Value(results).ToString();
     
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
