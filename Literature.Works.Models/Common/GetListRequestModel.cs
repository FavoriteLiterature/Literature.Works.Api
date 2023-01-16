namespace Literature.Works.Models.Common;

public class GetListRequestModel : PaginationModel
{
    public string? Query { get; set; }
    
    public bool OrderByDescending { get; set; }
}