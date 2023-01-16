using Literature.Works.Api.Entities;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Infrastructure.Abstractions;

public interface IRepository
{
    IQueryable<Work> Works { get; }
    IQueryable<Genre> Genres { get; }
    IQueryable<Author> Authors { get; }
    IQueryable<Attachment> Attachments { get; }
    IQueryable<AttachmentType> AttachmentTypes { get; }
    
    Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : BaseEntity;
    
    Task<int> SaveChangesAsync(CancellationToken token);
}