using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Works")]
public class Work : BaseEntity
{
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public float? Rating { get; set; } = null;
    public string? Description { get; set; }
    
    public List<Genre> Genres { get; set; }
}