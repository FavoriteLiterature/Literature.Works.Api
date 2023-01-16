using Literature.Works.Api.Entities;
using Literature.Works.Api.Infrastructure.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Application.Commands.Works;

public class AddWorkRequestHandler : IRequestHandler<AddWorkRequest>
{
    private readonly IRepository _repository;

    public AddWorkRequestHandler(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(AddWorkRequest request, CancellationToken cancellationToken)
    {
        var author = await _repository.Authors.FirstOrDefaultAsync(x => x.UserId == request.AuthorId, cancellationToken);
        
        if (author is null)
        {
            author = new Author
            {
                UserId = request.AuthorId
            };

            await _repository.AddAsync(author, cancellationToken);
        }

        var work = new Work
        {
            Name = request.Name,
            AuthorId = author.Id,
            Description = request.Description
        };
        
        if (request.Genres is not null)
        {
            foreach (var guid in request.Genres)
            {
                var genre = await _repository.Genres.FirstOrDefaultAsync(x => x.Id == guid, cancellationToken);
            
                if (genre is null)
                {
                    throw new ArgumentException("Genre not found!", nameof(genre.Id));
                }

                var genreWork = new GenreWork
                {
                    GenreId = genre.Id,
                    WorkId = work.Id
                };

                await _repository.AddAsync(genreWork, cancellationToken);
            }
        }

        await _repository.AddAsync(work, cancellationToken);

        if (request.Attachments is not null)
        {
            foreach (var attachment in request.Attachments)
            {
                if (!await _repository.AttachmentTypes.AnyAsync(x => x.Name == attachment.Type, cancellationToken))
                {
                    throw new ArgumentException("Attachment type not found!", nameof(attachment.Type));
                }

                var attachmentEntity = new Attachment
                {
                    WorkId = work.Id,
                    FileId = attachment.FileId,
                    TypeName = attachment.Type
                };

                await _repository.AddAsync(attachmentEntity, cancellationToken);
            }
        }
        
        await _repository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}