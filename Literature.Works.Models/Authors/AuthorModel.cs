namespace Literature.Works.Models.Authors;

public class AuthorModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? PublicEmail { get; set; }
    public DateTimeOffset Created { get; set; }
}