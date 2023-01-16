using AutoMapper;
using Literature.Works.Api.Entities;
using Literature.Works.Models.Authors;
using Literature.Works.Models.Genres;
using Literature.Works.Models.Works;

namespace Literature.Works.Api.Utils.Mapping;

public class WebApiProfile : Profile
{
    public WebApiProfile()
    {
        CreateMap<Author, AuthorModel>();
        
        CreateMap<Genre, GenreModel>();
        CreateMap<GenreModel, Genre>();
     
        CreateMap<Work, WorkModel>()
            .ForMember(
                workModel => workModel.Genres, 
                opt => opt.MapFrom(x => x.Genres.Select(y => y.Genre).ToList()));
        CreateMap<GenreWork, Genre>();
    }
}