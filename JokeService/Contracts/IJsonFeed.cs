using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeService.Contracts
{
    public interface IJsonFeed
    {
        //string Endpoint { 
        //    get { return ""; } 
        //    set { }
        //}
        string[] GetRandomJokes(JokeRequest request);
        string[] GetCategories(CategoryRequest request);
       // dynamic Getnames();
    }
}
