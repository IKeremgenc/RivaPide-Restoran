using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RivaWebUI.ApiEnpoints;
using RivaWebUI.Dtos.CategoryDtos;
using RivaWebUI.Dtos.ProductDtos;
using System.Text;

namespace RivaWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiProduct.DOMAIN);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiCategory.DOMAIN);
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }


                createProductDto.ImageUrl = "/images/" + fileName;
            }

            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(ApiProduct.DOMAIN2, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index","Product");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{ApiProduct.DOMAIN2}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync(ApiCategory.DOMAIN);
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            List<SelectListItem> values2 = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{ApiProduct.DOMAIN2}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, IFormFile newImage)
        {
            if (newImage != null && newImage.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(stream);
                }


                updateProductDto.ImageUrl = "/images/" + fileName;
            }
            else
            {

                updateProductDto.ImageUrl = updateProductDto.ImageUrl;
            }
            updateProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(ApiProduct.DOMAIN2, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Product");
        }

    }
}
