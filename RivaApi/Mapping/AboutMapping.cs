using AutoMapper;
using Riva.DtoLayer.AboutDto;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;

namespace RivaApi.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
