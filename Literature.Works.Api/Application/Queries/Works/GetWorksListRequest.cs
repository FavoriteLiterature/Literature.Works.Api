using Literature.Works.Models.Common;
using Literature.Works.Models.Works;
using MediatR;

namespace Literature.Works.Api.Application.Queries.Works;

public class GetWorksListRequest : GetListRequestModel, IRequest<CollectionModel<WorkModel>>
{
}