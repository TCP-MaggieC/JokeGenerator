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
        private string _urlJoke = "https://api.chucknorris.io";
        private string _urlName = "https://www.names.privserv.com/api/";
        public JokeCheckService(ILogger<JokeCheckService> logger, IJsonFeed feed)
        {
            _logger = logger;
            
            _feed = feed;
        }

        public override Task<JokeReply> CheckJokeRequest(JokeRequest request, ServerCallContext context)
        {
            request.Uri = _urlJoke;

            var response = _feed.GetRandomJokes(request);

                return Task.FromResult(new JokeReply
                {
                    Message = response//[0]
                });

        }

        public override Task<CategoryReply> CheckJokeCategoryRequest(CategoryRequest request, ServerCallContext context)
        {
            request.Uri = _urlJoke;
 
            var response = _feed.GetCategories(request);

            return Task.FromResult(new CategoryReply
            {
                Message = response[0]
            });
        }

        public override Task<NameReply> CheckJokeNameRequest(NameRequest request, ServerCallContext context)
        {
            request.Uri = _urlName;
            
            var response = _feed.GetNames(request);
         //   _names = Tuple.Create(response.name.ToString(), response.surname.ToString());
            return Task.FromResult(new NameReply
            {
                FirstName = response.name.ToString(),
                LastName = response.surname.ToString()
            });
        }


    }
}
