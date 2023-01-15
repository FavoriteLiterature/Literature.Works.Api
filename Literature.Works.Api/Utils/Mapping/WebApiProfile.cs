using AutoMapper;
using Literature.Works.Api.Entities;
using Literature.Works.Models.Genres;

namespace Literature.Works.Api.Utils.Mapping;

public class WebApiProfile : Profile
{
    public WebApiProfile()
    {
        CreateMap<Genre, GenreModel>();
    }
}