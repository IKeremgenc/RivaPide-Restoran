using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.DiscountDtos;

namespace RivaWebUI.ViewComponents.UIDetails
{
    public class _UIDiscount:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UIDiscount(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Discount/GetListByStatusTrue");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
            return View(values);
        }
    }
}
