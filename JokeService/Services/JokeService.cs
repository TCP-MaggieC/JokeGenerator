using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using JokeService.Contracts;


namespace JokeService
{
    public class JokeCheckService : JokeCheck.JokeCheckBase
    {
        private readonly ILogger<JokeCheckService> _logger;
        private IJsonFeed _feed;
        static string[] results = new string[50];
        static Tuple<string, string> names;

        public JokeCheckService(ILogger<JokeCheckService> logger, IJsonFeed feed)
        {
            _logger = logger;
            _feed = feed;
        }

        public override Task<JokeReply> CheckJokeRequest(JokeRequest request, ServerCallContext context)
        {

            var response = _feed.GetRandomJokes(request);

                return Task.FromResult(new JokeReply
                {
                    Message = response[0]
                });

        }

        public override Task<CategoryReply> CheckJokeCategoryRequest(CategoryRequest request, ServerCallContext context)
        {
            var response = _feed.GetCategories(request);

            return Task.FromResult(new CategoryReply
            {
                Message = response[0]
            });
        }


        //public string[] GetRandomJokes(JokeRequest request)
        //{
        //    var feed = new JsonFeed("https://api.chucknorris.io");//, request.Number);
        //    return feed.GetRandomJokes(request);
        //}

        //public string[]  GetCategories()
        //{
        //    var feed = new JsonFeed("https://api.chucknorris.io");//, 0);
        //    results = feed.GetCategories();
        //    return results;
        //}

        //public static void GetNames()
        //{
        //    var feed  = new JsonFeed("https://www.names.privserv.com/api/");//, 0);
        //    dynamic result = feed.Getnames();
        //    names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        //}

    }
}
