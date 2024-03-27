using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.BookingDtos;
using System.Net.Http;
using System.Text;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class RezController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RezController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            

            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(ApiBooking.DOMAIN, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyonunuz başarıyla yapıldı.😍";
             return RedirectToAction("Index","Default");
            }
            TempData["DangerMessage"] = " Rezervasyonunuz İşleminiz Gerçekletirilirken Bir Hata İle Karşılaştı .🤔";
            return RedirectToAction("Index", "Default");
        }

    }
}
