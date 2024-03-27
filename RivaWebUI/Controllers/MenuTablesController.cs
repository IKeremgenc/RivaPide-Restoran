using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.MenuTableDtos;
using System.Text;

namespace RivaWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuTablesController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public MenuTablesController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(ApiMenuTable.DOMAIN);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateMenuTable()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.Status = false;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMenuTableDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync(ApiMenuTable.DOMAIN, stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"{ApiMenuTable.DOMAIN}{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"{ApiMenuTable.DOMAIN}{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateMenuTableDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateMenuTableDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync(ApiMenuTable.DOMAIN, stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiMenuTable.DOMAIN);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }


	
		public async Task<IActionResult> MenuTableStatusApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{ApiMenuTable.DOMAIN}{ApiMenuTable.DiscountEnpoints.MenuTableStatusApproved}{id}");
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> MenuTableStatusFalseApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{ApiMenuTable.DOMAIN}{ApiMenuTable.DiscountEnpoints.MenuTableStatusFalseApproved}{id}");
			return RedirectToAction("Index");
		}

	}
}
