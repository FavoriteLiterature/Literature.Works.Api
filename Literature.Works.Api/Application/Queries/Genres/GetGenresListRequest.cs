using Literature.Works.Models.Common;
using Literature.Works.Models.Genres;
using MediatR;

namespace Literature.Works.Api.Application.Queries.Genres;

public class GetGenresListRequest : GetListRequestModel, IRequest<CollectionModel<GenreModel>>
{
}