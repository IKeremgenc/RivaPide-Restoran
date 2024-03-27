using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.TestimonialDtos;

namespace RivaWebUI.ViewComponents.UIDetails
{
    public class _UITestimonial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UITestimonial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Testimonial");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}
