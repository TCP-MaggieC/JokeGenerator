using System;
using System.Threading.Tasks;
using JokeService;
using Grpc.Net.Client;
namespace JokeClientConsole
{
    class Program
    {

        static char key;
        static ConsolePrinter printer = new ConsolePrinter();
  

        static async Task Main(string[] args)
        {
            while (true)
            {
                printer.Value("Press ? to get instructions.").ToString();
                GetEnteredKey(Console.ReadKey());
                //if (Console.ReadLine() == "?")
                if(key == '?')
                {
                    while (true)
                    {
                        // The port number(5001) must match the port of the gRPC server.
                        var channel = GrpcChannel.ForAddress("https://localhost:5001");
                        var client = new JokeCheck.JokeCheckClient(channel);

                        printer.Value("Press r to get random jokes").ToString();
                        GetEnteredKey(Console.ReadKey());

                        if (key == 'r')
                        {
                            var jokeRequest = new JokeRequest();

                            printer.Value("Want to specify a category? y/n").ToString();
                            GetEnteredKey(Console.ReadKey());
                            if (key == 'y')
                            {
                                printer.Value("Please select the category by typing the 1-9 or a-z inside[] following each category.").ToString();
                                printer.Value("'animal[1]','career[2],'celebrity[3]','dev[4]','explicit[5]','fashion[6]','food[7]','history[8]','money[9]','movie[a]','music[b]','political[c]','religion[d]','science[e]','sport[f]','travel[g]'").ToString();

                                jokeRequest.Category = MapCategoryKey(Console.ReadKey());
                            }

                            printer.Value("Want to use a random name? y/n").ToString();
                            GetEnteredKey(Console.ReadKey());
                            if (key == 'y')
                            {
                                var nameRequest = new NameRequest();

                                var nameReply = await client.CheckJokeNameRequestAsync(nameRequest);
                                jokeRequest.FirstName = nameReply.FirstName;
                                jokeRequest.LastName = nameReply.LastName;

                                Console.WriteLine($"Random name is {jokeRequest.FirstName} {jokeRequest.LastName} :-)");
                            }

                            printer.Value("How many jokes do you want? (1-9)").ToString();
                           //GetEnteredKey(Console.ReadLine());
                              int n = Int32.Parse(Console.ReadLine());
                         
                            jokeRequest.Number = n;

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
                            if (success)
                            {
                                Console.WriteLine($"Enjoy the joke for {jokeRequest.Category.ToUpper()} category: {reply.Message}");
                            }
                            else
                            {
                                Console.WriteLine($"Sorry, {reply.Message}");
                            }
                        }

                        Console.WriteLine("Press any key to continue new joke... Press ctrl+c to exit...");
                        Console.ReadKey();
                    }
                }
            
            
            }

           
        }



        private static string MapCategoryKey(ConsoleKeyInfo consoleKeyInfo)
        {
            var category = string.Empty;
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D1:
                    category = "animal";
                    break;
                case ConsoleKey.D2:
                    category = "career";
                    break;
                case ConsoleKey.D3:
                    category = "celebrity";
                    break;
                case ConsoleKey.D4:
                    category = "dev";
                    break;
                case ConsoleKey.D5:
                    category = "explicit";
                    break;
                case ConsoleKey.D6:
                    category = "fashion";
                    break;
                case ConsoleKey.D7:
                    category = "food";
                    break;
                case ConsoleKey.D8:
                    category = "history";
                    break;
                case ConsoleKey.D9:
                    category = "money";
                    break;
                case ConsoleKey.A:
                    category = "movie";
                    break;
                case ConsoleKey.B:
                    category = "music";
                    break;
                case ConsoleKey.C:
                    category = "political";
                    break;
                case ConsoleKey.D:
                    category = "religion";
                    break;
                case ConsoleKey.E:
                    category = "science";
                    break;
                case ConsoleKey.F:
                    category = "sport";
                    break;
                case ConsoleKey.G:
                    category = "travel";
                    break;
            }

            return category;
        }

        //private static void PrintResults()
        //{
        //    printer.Value(results).ToString();
     
        //}

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
                case ConsoleKey.Oem2:
                    key = '?';
                    break;
            }

            
        }

    }
}
