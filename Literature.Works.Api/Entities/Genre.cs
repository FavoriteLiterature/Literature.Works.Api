using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Genres")]
public class Genre : BaseEntityGuid
{
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public ICollection<GenreWork> Works { get; set; }
}