using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static string[] results = new string[50];
        static char key;
        static string category;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();

        static void Main(string[] args)
        {
            while (true)
            {
                printer.Value("Press ? to get instructions.").ToString();
                if (Console.ReadLine() == "?")
                {
                    while (true)
                    {
                      //  printer.Value("Press c to get categories").ToString();
                        printer.Value("Press r to get random jokes").ToString();
                        GetEnteredKey(Console.ReadKey());
                        //if (key == 'c')
                        //{
                        //    getCategories();
                        //    PrintResults();
                        //}
                        if (key == 'r')
                        {
                            printer.Value("Want to specify a category? y/n").ToString();
                            GetEnteredKey(Console.ReadKey());
                            if (key == 'y')
                            {
                                printer.Value("Please select the category by typing the 1-9 or a-z inside[] following each category.").ToString();
                                printer.Value("'animal[1]','career[2],'celebrity[3]','dev[4]','explicit[5]','fashion[6]','food[7]','history[8]','money[9]','movie[a]','music[b]','political[c]','religion[d]','science[e]','sport[f]','travel[g]'").ToString();
                                // PrintResults();
                                MapCategoryKey(Console.ReadKey());
                            }

                            printer.Value("Want to use a random name? y/n").ToString();
                            GetEnteredKey(Console.ReadKey());
                            if (key == 'y')
                            {
                                GetNames();
                            }
                            //printer.Value("Want to specify a category? y/n").ToString();
                            //if (key == 'y')
                            //{
                            //    printer.Value("How many jokes do you want? (1-9)").ToString();
                            //    int n = Int32.Parse(Console.ReadLine());
                            //    printer.Value("Enter a category;").ToString();
                            //    GetRandomJokes(Console.ReadLine(), n);
                            //    PrintResults();
                            //}
                            //else
                            //{
                                printer.Value("How many jokes do you want? (1-9)").ToString();
                                int n = Int32.Parse(Console.ReadLine());
                                GetRandomJokes(null, n);
                                PrintResults();
                           // }
                        }
                        names = null;
                    }
                }
            }
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

        private static string  MapCategoryKey(ConsoleKeyInfo consoleKeyInfo)
        {
            //var category = string.Empty;
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

        private static void GetRandomJokes(string category, int number)
        {
            new JsonFeed("https://api.chucknorris.io", number);
            results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        }

        private static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            results = JsonFeed.GetCategories();
        }

        private static void GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
