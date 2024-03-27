using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.ContactDtos;
using System.Text;

namespace RivaWebUI.Controllers
{
    public class UIContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UIContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
   
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiContact.DOMAIN);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
