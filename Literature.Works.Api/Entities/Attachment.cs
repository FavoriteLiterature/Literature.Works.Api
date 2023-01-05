using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

public class Attachment : BaseEntity
{
    public Guid WorkId { get; set; }
    public Guid FileId { get; set; }
    public string TypeName { get; set; }
}