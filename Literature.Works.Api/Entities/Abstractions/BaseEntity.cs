namespace Literature.Works.Api.Entities.Abstractions;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Created = DateTimeOffset.UtcNow;
    }
    public DateTimeOffset Created { get; init; }
}