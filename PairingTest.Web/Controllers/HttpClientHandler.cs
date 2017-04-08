using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PairingTest.Web.Controllers
{
    public class HttpClientHandler : IHttpHandler
    {
        private HttpClient _client = new HttpClient();

        public HttpClientHandler(Uri address)
        {
            _client.BaseAddress = address;
        }

        public HttpResponseMessage Get()
        {
            return GetAsync().Result;
        }

        public HttpResponseMessage Post(HttpContent content)
        {
            return PostAsync(content).Result;
        }

        public async Task<HttpResponseMessage> GetAsync()
        {
            return await _client.GetAsync(_client.BaseAddress);
        }

        public async Task<HttpResponseMessage> PostAsync(HttpContent content)
        {
            return await _client.PostAsync(_client.BaseAddress, content);
        }
    }
}