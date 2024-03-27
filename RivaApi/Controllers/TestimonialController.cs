using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.BusinessLayer.Abstract;
using Riva.DtoLayer.ProductDto;
using Riva.DtoLayer.TestimonialDto;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using RivaEntityLayer.Entities;


namespace RivaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestoimonialService _testoimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestoimonialService testoimonialService, IMapper mapper)
        {
            _testoimonialService = testoimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testoimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testoimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDto.Comment,
         
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
             
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testoimonialService.TGetByID(id);
            _testoimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testoimonialService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testoimonialService.TUpdate(new Testimonial()
            {
                Comment = updateTestimonialDto.Comment,
             
                Name = updateTestimonialDto.Name,
                Status = updateTestimonialDto.Status,
         
                TestimonialID= updateTestimonialDto.TestimonialID
            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }
    }
}
