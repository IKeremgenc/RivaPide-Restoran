using AutoMapper;
using Riva.DtoLayer.BookingDto;
using Riva.EntityLayer.Entities;

namespace RivaApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
