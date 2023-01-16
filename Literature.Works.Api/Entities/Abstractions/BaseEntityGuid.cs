namespace Literature.Works.Api.Entities.Abstractions;

public abstract class BaseEntityGuid : BaseEntity
{
    public BaseEntityGuid()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; init; }
}