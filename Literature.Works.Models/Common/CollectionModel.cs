namespace Literature.Works.Models.Common;

public class CollectionModel<T> where T : class
{
    public CollectionModel(ICollection<T> items, int length)
    {
        Items = items;
        Length = length;
    }
    
    public int Length { get; }

    public ICollection<T> Items { get; }
}