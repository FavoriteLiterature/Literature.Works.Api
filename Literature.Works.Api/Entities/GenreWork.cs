using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

public class GenreWork : BaseEntity
{
    public Guid GenreId { get; set; }
    public Genre Genre { get; set; }

    public Guid WorkId { get; set; }
    public Work Work { get; set; }
}