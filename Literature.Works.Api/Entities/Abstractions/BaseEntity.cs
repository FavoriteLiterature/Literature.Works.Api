namespace Literature.Works.Api.Entities.Abstractions;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        Created = DateTimeOffset.UtcNow;
    }
    
    public Guid Id { get; init; }
    public DateTimeOffset Created { get; init; }
}