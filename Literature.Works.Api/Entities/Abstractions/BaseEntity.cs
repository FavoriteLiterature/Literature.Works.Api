namespace Literature.Works.Api.Entities.Abstractions;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        Created = DateTimeOffset.Now;
    }
    
    public Guid Id { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset? Updated { get; set; }
}