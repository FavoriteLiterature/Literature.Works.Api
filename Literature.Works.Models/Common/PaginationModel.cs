namespace Literature.Works.Models.Common;

public class PaginationModel
{
    private readonly int _skip;
    private readonly int _take = 20;
    
    public int Skip
    {
        get => _skip;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("Value can't be less 0", nameof(Skip));
            }

            _skip = value;
        }
    }
    
    public int Take
    {
        get => _take;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("Value can't be less 0", nameof(Take));
            }

            _take = value;
        }
    }
}