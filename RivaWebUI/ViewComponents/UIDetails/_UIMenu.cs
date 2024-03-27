using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.ProductDtos;

namespace RivaWebUI.ViewComponents.UIDetails
{
    public class _UIMenu:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UIMenu(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
    }
}
