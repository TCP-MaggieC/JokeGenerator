using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace JokeService
{
    public class JokeCheckService : JokeCheck.JokeCheckBase
    {
        private readonly ILogger<JokeCheckService> _logger;
        static string[] results = new string[500/*50*/];
        static Tuple<string, string> names;
        //private static readonly Dictionary<string, Int32> customerTrustedCredit = new Dictionary<string, Int32>()
        //{
        //    {"id0201", 10000},
        //    {"id0417", 5000},
        //    {"id0306", 15000}
        //};
        public JokeCheckService(ILogger<JokeCheckService> logger)
        {
            _logger = logger;
        }

        public override Task<JokeReply> CheckJokeRequest(JokeRequest request, ServerCallContext context)
        {
            var response = GetRandomJokes(request, 1);

            return Task.FromResult(new JokeReply
            {
                Message = response[0]
            }) ;

        }

        //private static void GetRandomJokes(string category, int number)
        //{
        //    new JsonFeed("https://api.chucknorris.io", number);
        //    results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        //}


        public string[] GetRandomJokes(JokeRequest request, int number)
        {
            //new JsonFeed("https://api.chucknorris.io", number);
           
            //return JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);

            var feed = new JsonFeed("https://api.chucknorris.io", number);
            return feed.GetRandomJokes(request.Name, request.Name,request.Category);
        }

        public static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            results = JsonFeed.GetCategories();
        }

        public static void GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }

        //private bool IsEligibleForCredit(string customerId, Int32 credit)
        //{
        //    bool isEligible = false;

        //    if (customerTrustedCredit.TryGetValue(customerId, out Int32 maxCredit))
        //    {
        //        isEligible = credit <= maxCredit;
        //    }

        //    return isEligible;
        //}
    }
}
