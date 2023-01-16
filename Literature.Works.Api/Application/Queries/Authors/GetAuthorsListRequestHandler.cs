using AutoMapper;
using Literature.Works.Api.Infrastructure.Abstractions;
using Literature.Works.Models.Authors;
using Literature.Works.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Application.Queries.Authors;

public class GetAuthorsListRequestHandler : IRequestHandler<GetAuthorsListRequest, CollectionModel<AuthorModel>>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorsListRequestHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CollectionModel<AuthorModel>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
    {
        var query = _repository.Authors.AsQueryable();
        var count = await query.CountAsync(cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.Query))
        {
            var pattern = $"%{request.Query}%";
            query = query.Where(x => x.PublicEmail != null && EF.Functions.ILike(x.PublicEmail, pattern));
        }
        
        var authors = await query
            .OrderBy(x => x.Created)
            .Skip(request.Skip)
            .Take(request.Take)
            .ToArrayAsync(cancellationToken);

        var result = _mapper.Map<AuthorModel[]>(authors);

        return new CollectionModel<AuthorModel>(result, count);
    }
}