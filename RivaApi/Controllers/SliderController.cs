using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.BusinessLayer.Abstract;
using Riva.DtoLayer.DiscountDto;
using Riva.DtoLayer.FeatureDto;
using Riva.DtoLayer.SliderDto;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;

namespace RivaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Description1 = createSliderDto.Description1,
         
                Title1 = createSliderDto.Title1,
                ImageUrl = createSliderDto.ImageUrl

            });
            return Ok("Öne Çıkan Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                Description1 = updateSliderDto.Description1,
    
                Title1 = updateSliderDto.Title1,
            
                SliderID= updateSliderDto.SliderID,
                ImageUrl = updateSliderDto.ImageUrl
            });
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }
    }
}
