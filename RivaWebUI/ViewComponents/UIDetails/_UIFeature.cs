using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.SliderDtos;

namespace RivaWebUI.ViewComponents.UIDetails
{
    public class _UIFeature:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UIFeature(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Slider");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
        }
    }
}
