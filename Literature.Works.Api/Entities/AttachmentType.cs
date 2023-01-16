using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Literature.Works.Api.Entities.Abstractions;

namespace Literature.Works.Api.Entities;

[Table("AttachmentTypes")]
public class AttachmentType : BaseEntity
{
    [Key]
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Attachment> Attachments { get; set; } = new();
}

public enum AttachmentTypes
{
    Cover,      // Обложка
    Image,      // Картинка
    Document    // Документ
}