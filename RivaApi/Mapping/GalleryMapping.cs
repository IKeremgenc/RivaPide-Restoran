using AutoMapper;
using Riva.DtoLayer.GalleryDto;
using Riva.EntityLayer.Entities;

namespace RivaApi.Mapping
{
    public class GalleryMapping:Profile
    {
        public GalleryMapping()
        {
            CreateMap<Gallery, ResultGallery>().ReverseMap();
            CreateMap<Gallery, CreateGallery>().ReverseMap();
        }
    }
}
