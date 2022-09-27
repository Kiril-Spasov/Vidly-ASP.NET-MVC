using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>()
                .ReverseMap()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}
