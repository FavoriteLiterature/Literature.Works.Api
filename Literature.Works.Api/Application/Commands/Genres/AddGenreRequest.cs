using Literature.Works.Models.Genres;
using MediatR;

namespace Literature.Works.Api.Application.Commands.Genres;

public class AddGenreRequest : AddGenreRequestModel, IRequest<GenreModel>
{
}