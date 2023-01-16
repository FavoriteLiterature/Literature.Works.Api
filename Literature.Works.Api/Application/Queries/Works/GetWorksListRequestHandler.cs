using AutoMapper;
using Literature.Works.Api.Extensions;
using Literature.Works.Api.Infrastructure.Abstractions;
using Literature.Works.Models.Common;
using Literature.Works.Models.Works;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Application.Queries.Works;

public class GetWorksListRequestHandler : IRequestHandler<GetWorksListRequest, CollectionModel<WorkModel>>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public GetWorksListRequestHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CollectionModel<WorkModel>> Handle(GetWorksListRequest request, CancellationToken cancellationToken)
    {
        var queryWorks = _repository.Works.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(request.Query))
        {
            var pattern = $"%{request.Query}%";
            queryWorks = queryWorks.Where(x => EF.Functions.ILike(x.Name, pattern));
        }
        
        var count = await queryWorks.CountAsync(cancellationToken);

        var works = await queryWorks
            .Include(x => x.Genres)
            .ThenInclude(x => x.Genre)
            .OrderBy(x => x.Name, request.OrderByDescending)
            .Skip(request.Skip)
            .Take(request.Take)
            .ToArrayAsync(cancellationToken);
        
        var result = _mapper.Map<WorkModel[]>(works);

        return new CollectionModel<WorkModel>(result, count);
    }
}