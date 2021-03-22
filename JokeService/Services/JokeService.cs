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
        static string[] results = new string[50];
        static Tuple<string, string> names;

        public JokeCheckService(ILogger<JokeCheckService> logger)
        {
            _logger = logger;
        }

        public override Task<JokeReply> CheckJokeRequest(JokeRequest request, ServerCallContext context)
        {


                var response = GetRandomJokes(request);

                return Task.FromResult(new JokeReply
                {
                    Message = response[0]
                });


        }

        public override Task<CategoryReply> CheckJokeCategoryRequest(CategoryRequest request, ServerCallContext context)
        {
            var response = GetCategories();

            return Task.FromResult(new CategoryReply
            {
                Message = response[0]
            });
        }


        public string[] GetRandomJokes(JokeRequest request)
        {
            var feed = new JsonFeed("https://api.chucknorris.io", request.Number);
            return feed.GetRandomJokes(request);
        }

        public string[]  GetCategories()
        {
            var feed = new JsonFeed("https://api.chucknorris.io", 0);
            results = feed.GetCategories();
            return results;
        }

        public static void GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }

    }
}
