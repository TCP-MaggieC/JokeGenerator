using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JokeService.Contracts;

namespace JokeService
{
    public class JsonFeed :IJsonFeed
    {

        //static string _url = "";
        // public JsonFeed() { }
        //public JsonFeed(string endpoint)
        //{
        //    _url = endpoint;
        //}

        static HttpClient _client = new HttpClient();

        public string[] GetRandomJokes(JokeRequest request)
		{
			//HttpClient client = new HttpClient();
			_client.BaseAddress = new Uri(request.Uri);
			string url = "jokes/random";
			if (request.Category != null)
			{
				if (url.Contains('?'))
					url += "&";
				else url += "?";
				url += "category=";
				url += request.Category;
			}

			string joke = Task.FromResult(_client.GetStringAsync(url).Result).Result;

            if (request.FirstName != null && request.LastName != null)
            {
                int index = joke.IndexOf("Chuck Norris");
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + request.FirstName + " " + request.LastName + secondPart;
            }

            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }


		public dynamic GetNames(NameRequest request)
        {
           // HttpClient client = new HttpClient();
            _client.BaseAddress = new Uri(request.Uri);
            var result = _client.GetStringAsync("").Result;
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public string[] GetCategories(CategoryRequest request)
		{
			//HttpClient client = new HttpClient();
			_client.BaseAddress = new Uri(request.Uri);//(_url);//new Uri(_url);
			//return new string[] { Task.FromResult(client.GetStringAsync("categories").Result).Result }; //Maggie bug fix to correct uri
			return new string[] { Task.FromResult(_client.GetStringAsync("jokes/categories").Result).Result };
		}
    }
}
