using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.Dtos.GalleryDto;
using System.Net.Http;

namespace RivaWebUI.ViewComponents.UIDetails
{
    public class _UIGalery:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _UIGalery(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task< IViewComponentResult >InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7186/api/Gallery");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultGallery>>(jsonData);
			return View(values);
		}
    }
}
