namespace Literature.Works.Api.Entities;

public class AttachmentType
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public enum AttachmentTypes
{
    Cover,      // Обложка
    Image,      // Картинка
    Document    // Документ
}