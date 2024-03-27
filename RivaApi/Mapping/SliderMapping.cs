using AutoMapper;
using Riva.DtoLayer.SliderDto;
using Riva.EntityLayer.Entities;

namespace RivaApi.Mapping
{
	public class SliderMapping:Profile
	{
        public SliderMapping()
        {
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
		}
    }
}
