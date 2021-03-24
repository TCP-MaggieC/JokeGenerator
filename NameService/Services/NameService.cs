using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using NameService.Contracts;
using Newtonsoft.Json;

namespace NameService
{
    public class NameCheckService : NameCheck.NameCheckBase, INameCheckService
    {
        private readonly ILogger<NameCheckService> _logger;
        private string _url =@"https://www.names.privserv.com/api/";
        public NameCheckService(string endpoint)
        {
            _url = endpoint;
        }
        public NameCheckService(ILogger<NameCheckService> logger)
        {
            _logger = logger;
          
        }

        public override Task<NameReply> CheckNameRequest(NameRequest request, ServerCallContext context)
        {
            var resp = GetName();

            return Task.FromResult(new NameReply
            {
                Message = resp
            });
        }

        public dynamic GetName()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			var result = client.GetStringAsync("").Result;
			return JsonConvert.DeserializeObject<dynamic>(result);
		}
    }
}
