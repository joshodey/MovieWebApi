using AutoMapper;
using MoviesWebApi.DTO;
using MoviesWebApi.Entities;

namespace MoviesWebApi.Extensions
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<MoviesDto, Movies>().ReverseMap();
        }
    }
}
