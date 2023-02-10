using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models;

namespace HotelListingAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        }
    }
}
