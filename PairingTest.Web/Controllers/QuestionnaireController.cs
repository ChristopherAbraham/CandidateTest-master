using System;
using System.Web.Mvc;
using PairingTest.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IHttpHandler _handler;

        public QuestionnaireController()
        {
            _handler = new HttpClientHandler(new Uri("http://localhost:50014/api/questions"));
        }

        public async Task<ActionResult> Index()
        {
            QuestionnaireViewModel viewModel = new QuestionnaireViewModel();

            HttpResponseMessage responseMessage = await _handler.GetAsync();

            if(responseMessage.IsSuccessStatusCode)
            {
                var questionResponse = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<QuestionnaireViewModel>(questionResponse);
            }
            else
            {
                throw new Exception("Response not successful");
            }

            return View(viewModel);
        }
    }
}
