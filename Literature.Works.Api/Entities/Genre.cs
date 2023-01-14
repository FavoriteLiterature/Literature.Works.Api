using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Genres")]
public class Genre : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}