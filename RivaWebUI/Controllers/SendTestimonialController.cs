using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.TestimonialDtos;
using System.Net.Http;
using System.Text;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class SendTestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SendTestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (HttpContext.User.Identity.IsAuthenticated) 
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(ApiTestimonial.DOMAIN, stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Yorumunuz İçin Teşşekürler .😍";
                    return RedirectToAction("Index", "Default");
                }
                TempData["DangerMessage"] = "Yorumunuz yapılmadı, bir hata oluştu Lütfen Giriş Yaptığınıza Emin Olun.Eğer Hala Hata Devam Ediyorsa Bizimle iletişime geçin🤔";
                return RedirectToAction("Index", "Default");
            }
            else
            {
                TempData["DangerMessage"] = "Yorumunuz yapılmadı, bir hata oluştu Lütfen Giriş Yaptığınıza Emin Olun.Eğer Hala Hata Devam Ediyorsa Bizimle iletişime geçin🤔";
                return RedirectToAction("Index", "Default");
            }
        }
    }
}
