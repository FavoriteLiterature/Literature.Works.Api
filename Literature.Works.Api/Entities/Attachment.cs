using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("Attachments")]
public class Attachment : BaseEntity
{
    public Guid WorkId { get; set; }
    public Guid FileId { get; set; }
    public string TypeName { get; set; }
}