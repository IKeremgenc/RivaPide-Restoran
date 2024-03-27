using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.BusinessLayer.Abstract;
using Riva.DtoLayer.GalleryDto;
using Riva.EntityLayer.Entities;

namespace RivaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _galleryService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateGallery CreateGallery)
        {
            Gallery Galery = new Gallery()
            {
               Galerry = CreateGallery.Galerry,
            };
            _galleryService.TAdd(Galery);
            return Ok("Resaim Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _galleryService.TGetByID(id);
            _galleryService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(ResultGallery ResultGallery)
        {
            Gallery Galery = new Gallery()
            {
                Galerry = ResultGallery.Galerry,
            };
            _galleryService.TUpdate(Galery);
            return Ok("Resim Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _galleryService.TGetByID(id);
            return Ok(value);
        }

    }
}
