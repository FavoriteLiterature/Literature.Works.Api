using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

public class Author : BaseEntity
{
    public Guid UserId { get; set; }
    public string PublicEmail { get; set; }
    
    public List<Work> Works { get; set; }
}