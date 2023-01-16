using AutoMapper;
using Literature.Works.Api.Entities;
using Literature.Works.Api.Infrastructure.Abstractions;
using Literature.Works.Models.Genres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Application.Commands.Genres;

public class AddGenreRequestHandler : IRequestHandler<AddGenreRequest, GenreModel>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public AddGenreRequestHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GenreModel> Handle(AddGenreRequest request, CancellationToken cancellationToken)
    {
        if (await _repository.Genres
                .AnyAsync(x => EF.Functions.ILike(x.Name, request.Name),
                    cancellationToken))
        {
            throw new ArgumentException("Duplicates are not allowed", nameof(request.Name));
        }

        var genre = new Genre
        {
            Name = request.Name,
            Description = request.Description
        };

        await _repository.AddAsync(genre, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GenreModel>(genre);
    }
}