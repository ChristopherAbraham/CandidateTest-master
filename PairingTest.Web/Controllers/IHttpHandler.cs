using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Controllers
{
    public interface IHttpHandler
    {
        HttpResponseMessage Get();
        HttpResponseMessage Post(HttpContent content);
        Task<HttpResponseMessage> GetAsync();
        Task<HttpResponseMessage> PostAsync(HttpContent content);
    }
}