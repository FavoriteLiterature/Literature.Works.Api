using Literature.Works.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Infrastructure.Abstractions;

public interface IDataContext
{
    DbSet<Work> DbWorks { get; set; }
    DbSet<Genre> DbGenres { get; set; }
    DbSet<GenreWork> DbGenreWorks { get; set; }
    DbSet<Author> DbAuthors { get; set; }
    DbSet<Attachment> DbAttachments { get; set; }
    DbSet<AttachmentType> DbAttachmentTypes { get; set; }
}