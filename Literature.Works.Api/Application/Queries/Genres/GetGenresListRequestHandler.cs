using AutoMapper;
using Literature.Works.Api.Extensions;
using Literature.Works.Api.Infrastructure.Abstractions;
using Literature.Works.Models.Common;
using Literature.Works.Models.Genres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Application.Queries.Genres;

public class GetGenresListRequestHandler : IRequestHandler<GetGenresListRequest, CollectionModel<GenreModel>>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    
    public GetGenresListRequestHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<CollectionModel<GenreModel>> Handle(GetGenresListRequest request, CancellationToken cancellationToken)
    {
        var query = _repository.Genres.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(request.Query))
        {
            var pattern = $"%{request.Query}%";
            query = query.Where(x => EF.Functions.ILike(x.Name, pattern));
        }

        var count = await query.CountAsync(cancellationToken);

        var genres = await query
            .OrderBy(x => x.Name, request.OrderByDescending)
            .Skip(request.Skip)
            .Take(request.Take)
            .ToArrayAsync(cancellationToken);

        var result = _mapper.Map<GenreModel[]>(genres);

        return new CollectionModel<GenreModel>(result, count);
    }
}