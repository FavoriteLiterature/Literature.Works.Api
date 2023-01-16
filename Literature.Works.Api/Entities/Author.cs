using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Authors")]
public class Author : BaseEntityGuid
{
    public Guid UserId { get; set; }
    public string? PublicEmail { get; set; }
    
    public List<Work> Works { get; set; }
}