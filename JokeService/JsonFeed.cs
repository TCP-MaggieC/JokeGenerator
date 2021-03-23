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
      // ---begin to remove once get mock unit test working----
		static string _url = "";
        public JsonFeed() { }
        public JsonFeed(string endpoint)//, int results)
        {
            _url = endpoint;
        }
		// ------end--------
        public string[] GetRandomJokes(JokeRequest request)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(request.Uri);//(_url);
			string url = "jokes/random";
			if (request.Category != null)
			{
				if (url.Contains('?'))
					url += "&";
				else url += "?";
				url += "category=";
				url += request.Category;
			}

			string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

            if (request.FirstName != null && request.LastName != null)
            {
                int index = joke.IndexOf("Chuck Norris");
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + request.FirstName + " " + request.LastName + secondPart;
            }

            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }

        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
		//public dynamic Getnames()
		//{
		//	HttpClient client = new HttpClient();
		//	client.BaseAddress = new Uri(_url);
		//	var result = client.GetStringAsync("").Result;
		//	return JsonConvert.DeserializeObject<dynamic>(result);
		//}

		public string[] GetCategories(CategoryRequest request)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(request.Uri);//(_url);//new Uri(_url);
			//return new string[] { Task.FromResult(client.GetStringAsync("categories").Result).Result }; //Maggie bug fix to correct uri
			return new string[] { Task.FromResult(client.GetStringAsync("jokes/categories").Result).Result };
		}
    }
}
