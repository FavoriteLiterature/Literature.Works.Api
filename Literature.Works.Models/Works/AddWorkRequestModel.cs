using Literature.Works.Models.Attachments;

namespace Literature.Works.Models.Works;

public class AddWorkRequestModel
{
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public string? Description { get; set; }
    public List<Guid>? Genres { get; set; }
    public List<AttachmentModel>? Attachments { get; set; }
}