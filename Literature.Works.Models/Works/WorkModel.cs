using Literature.Works.Models.Genres;

namespace Literature.Works.Models.Works;

public class WorkModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public float? Rating { get; set; }
    public string? Description { get; set; }
    public IList<GenreModel> Genres { get; set; }
}