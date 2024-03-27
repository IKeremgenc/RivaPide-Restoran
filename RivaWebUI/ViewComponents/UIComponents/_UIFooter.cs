using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.ContactDtos;

namespace RivaWebUI.ViewComponents.UIComponents
{
    public class _UIFooter:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UIFooter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Contact");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
    }
}
