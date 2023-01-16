using Literature.Works.Models.Authors;
using Literature.Works.Models.Common;
using MediatR;

namespace Literature.Works.Api.Application.Queries.Authors;

public class GetAuthorsListRequest : GetListRequestModel, IRequest<CollectionModel<AuthorModel>>
{
}