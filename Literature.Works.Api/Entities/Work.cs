using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Works")]
public class Work : BaseEntityGuid
{
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public float? Rating { get; set; }
    public string? Description { get; set; }
    
    public ICollection<GenreWork> Genres { get; set; }
}