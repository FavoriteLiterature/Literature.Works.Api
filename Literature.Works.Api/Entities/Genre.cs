using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}