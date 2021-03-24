using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeService.Contracts
{
    public interface IJsonFeed
    {

        string[] GetRandomJokes(JokeRequest request);
        string[] GetCategories(CategoryRequest request);
        dynamic GetNames(NameRequest request);
    }
}
