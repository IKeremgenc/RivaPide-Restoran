using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riva.BusinessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DtoLayer.BasketDto;
using Riva.EntityLayer.Entities;
using RivaApi.Models;




namespace RivaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new RivaPideContext();
            var values = context.Baskets.Include(x => x.Product).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                Count = z.Count,
                //MenuTableID = z.MenuTableID,
                Price = z.Price,
                ProductID = z.ProductID,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            //Bahçe 01 --> 45
            using var context = new RivaPideContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                //MenuTableID = 4,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
