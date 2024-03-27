using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.DiscountDtos;
using System.Text;

namespace RivaWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiDiscount.DOMAIN);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto, IFormFile NewImage)
        {
            if (NewImage != null && NewImage.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(NewImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NewImage.CopyToAsync(stream);
                }


                createDiscountDto.ImageUrl = "/images/" + fileName;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(ApiDiscount.DOMAIN, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{ApiDiscount.DOMAIN}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{ApiDiscount.DOMAIN}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto, IFormFile newImage)
        {
            if (newImage != null && newImage.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(stream);
                }


                updateDiscountDto.ImageUrl = "/images/" + fileName;
            }
            else
            {

                updateDiscountDto.ImageUrl = updateDiscountDto.ImageUrl;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(ApiDiscount.DOMAIN, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

		public async Task<IActionResult> ChangeStatusToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{ApiDiscount.DOMAIN}{ApiDiscount.DiscountEnpoints.ChangeStatusToTrue}{id}");
            return RedirectToAction("Index");
		}

		public async Task<IActionResult> ChangeStatusToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{ApiDiscount.DOMAIN}{ApiDiscount.DiscountEnpoints.ChangeStatusToFalse}{id}");
			return RedirectToAction("Index");
		}
	}
}
